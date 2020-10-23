import * as React from 'react';
import { Row, Col, Card, Icon, List, Avatar } from 'antd';
import './index.less';
import BarChartExample from './components/BarChartExample';
import PieChartExample from './components/PieChartExample';
import ProjectStore from '../../stores/projectStore';
import { inject, observer } from 'mobx-react';
import Stores from '../../stores/storeIdentifier';
import moment from 'moment';

export interface IDashboardProps {
  projectStore: ProjectStore;
}

export interface IDashboardState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  projectId: number;
  filter: string;
  cardLoading: boolean;
}


@inject(Stores.ProjectStore)
@observer
export class Dashboard extends React.Component<IDashboardProps, IDashboardState> {

  state = {
    modalVisible: false,
    maxResultCount: 4,
    skipCount: 0,
    projectId: 0,
    filter: '',
    cardLoading: true,
  };

  async componentDidMount() {
    setTimeout(() => this.setState({ cardLoading: false }), 1000);
    await this.getAll();
  }

  async getAll() {
    await this.props.projectStore.getAll({ maxResultCount: this.state.maxResultCount, skipCount: this.state.skipCount, keyword: this.state.filter });
  }

  handleTableChange = (pagination: any) => {
    this.setState({ skipCount: (pagination.current - 1) * this.state.maxResultCount! }, async () => await this.getAll());
  };

  

  render() {
    const { cardLoading } = this.state;
    const { projects } = this.props.projectStore;

    /* const listData = [{}];

    for (let i = 0; i < 23; i++) {
      listData.push({
        href: 'https://ant.design',
        title: `ant design part ${i}`,
        avatar: 'https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png',
        description:
          'Ant Design, a design language for background applications, is refined by Ant UED Team.',
        content:
          'We supply a series of design principles, practical patterns and high quality design resources (Sketch and Axure), to help people create their product prototypes beautifully and efficiently.',
      });
    } */

    const IconText = (icon: string, text: string ) => (
      <span>
      <Icon type={icon} style={{ marginRight: 8 }} />
      {text}
    </span>
    );

    return (
      <React.Fragment>


        <Row gutter={16}>
          <Col>
            
          <Card title="Projects" className={'dashboardBox'} bordered={false}>
          <List
    itemLayout="vertical"
    size="large"
    pagination={{ pageSize: this.state.maxResultCount, total: projects === undefined ? 0 : projects.totalCount, defaultCurrent: 1,
      onChange: x => {
      console.log(x);
      this.setState({ skipCount: (x - 1) * this.state.maxResultCount! }, async () => await this.getAll());
      
    } }}
    dataSource={projects === undefined ? [] : projects.items}

    renderItem={item  => (
      <List.Item
        key={item.name}
      >
        <List.Item.Meta
          title={<a>{item.name}</a>}
          description={ moment(item.startdate).format("MMMM Do, YYYY") + " to " + (moment(item.enddate).isAfter(moment("0001-01-01")) ? moment(item.enddate).format("MMMM Do, YYYY") : "Ongoing")}
        />
        <div className="totalCost textEnd">{"Total Cost: " + item.totalCost}</div>
        <div className="textEnd">{"Base Cost: " + item.cost}</div>
        <div>Team Members: {item.employees.map(x => x.name + ", ").length>0 ? item.employees.map(x => x.name + ", ") : "Nobody " }</div>
        
      </List.Item>
    )}
  />
          </Card>

          </Col>
         
        </Row>
      </React.Fragment>
    );
  }
}

export default Dashboard;
