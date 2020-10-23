import * as React from 'react';
import { Row, Col, Card, Icon, List, Avatar } from 'antd';
import './index.less';
import BarChartExample from './components/BarChartExample';
import PieChartExample from './components/PieChartExample';
import ProjectStore from '../../stores/projectStore';
import { inject, observer } from 'mobx-react';
import Stores from '../../stores/storeIdentifier';

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
    maxResultCount: 10,
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
          <Col
            className={'dashboardCard'}
            xs={{ offset: 1, span: 22 }}
            sm={{ offset: 1, span: 22 }}
            md={{ offset: 1, span: 11 }}
            lg={{ offset: 1, span: 11 }}
            xl={{ offset: 0, span: 6 }}
            xxl={{ offset: 0, span: 6 }}
          >
            <Card className={'dasboardCard-task'} bodyStyle={{ padding: 10 }} loading={cardLoading} bordered={false}>
              <Col span={8}>
                <Icon className={'dashboardCardIcon'} type="check" />
              </Col>
              <Col span={16}>
                <p className={'dashboardCardName'}>New Task</p>
                <label className={'dashboardCardCounter'}>125</label>
              </Col>
            </Card>
          </Col>
          <Col
            className={'dashboardCard'}
            xs={{ offset: 1, span: 22 }}
            sm={{ offset: 1, span: 22 }}
            md={{ offset: 1, span: 11 }}
            lg={{ offset: 1, span: 11 }}
            xl={{ offset: 0, span: 6 }}
            xxl={{ offset: 0, span: 6 }}
          >
            <Card className={'dasboardCard-ticket'} bodyStyle={{ padding: 10 }} loading={cardLoading} bordered={false}>
              <Col span={8}>
                <Icon className={'dashboardCardIcon'} type="question" />
              </Col>
              <Col span={16}>
                <p className={'dashboardCardName'}>New Ticket</p>
                <label className={'dashboardCardCounter'}>257</label>
              </Col>
            </Card>
          </Col>
          <Col
            className={'dashboardCard'}
            xs={{ offset: 1, span: 22 }}
            sm={{ offset: 1, span: 22 }}
            md={{ offset: 1, span: 11 }}
            lg={{ offset: 1, span: 11 }}
            xl={{ offset: 0, span: 6 }}
            xxl={{ offset: 0, span: 6 }}
          >
            <Card className={'dasboardCard-comment'} bodyStyle={{ padding: 10 }} loading={cardLoading} bordered={false}>
              <Col span={8}>
                <Icon className={'dashboardCardIcon'} type="message" />
              </Col>
              <Col span={16}>
                <p className={'dashboardCardName'}>New Comments</p>
                <label className={'dashboardCardCounter'}>243</label>
              </Col>
            </Card>
          </Col>
          <Col
            className={'dashboardCard'}
            xs={{ offset: 1, span: 22 }}
            sm={{ offset: 1, span: 22 }}
            md={{ offset: 1, span: 11 }}
            lg={{ offset: 1, span: 11 }}
            xl={{ offset: 0, span: 6 }}
            xxl={{ offset: 0, span: 6 }}
          >
            <Card className={'dasboardCard-visitor'} bodyStyle={{ padding: 10 }} loading={cardLoading} bordered={false}>
              <Col span={8}>
                <Icon className={'dashboardCardIcon'} type="user-add" />
              </Col>
              <Col span={16}>
                <p className={'dashboardCardName'}>New Visitors</p>
                <label className={'dashboardCardCounter'}>1225</label>
              </Col>
            </Card>
          </Col>
        </Row>

        <Row gutter={16}>
          <Col span={16}>
            
          <Card title="Projects" className={'dashboardBox'} bordered={false}>
          <List
    itemLayout="vertical"
    size="large"
    pagination={{ pageSize: this.state.maxResultCount, total: projects === undefined ? 0 : projects.totalCount, defaultCurrent: 1 }}
    dataSource={projects === undefined ? [] : projects.items}
    footer={
      <div>
        <b>ant design</b> footer part
      </div>
    }
    renderItem={item  => (
      <List.Item
        key={item.name}
        actions={[
          "test", "test"
        ]}
      >
        <List.Item.Meta
          title={<a href={item.name}>{item.name}</a>}
          description={item.startdate}
        />
        {item.cost}
      </List.Item>
    )}
  />
          </Card>

          </Col>
          <Col span={8}>
            <Card title="Browser Usage" className={'dashboardBox'} bordered={false}>
              <PieChartExample />
            </Card>
          </Col>
        </Row>
      </React.Fragment>
    );
  }
}

export default Dashboard;
