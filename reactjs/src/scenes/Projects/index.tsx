import './index.less';
import * as React from 'react';

import { Button, Card, Col, Dropdown, Input, Menu, Modal, Row, Table, Tag, /* Tag */ } from 'antd';
import { inject, observer } from 'mobx-react';

import AppComponentBase from '../../components/AppComponentBase';
import CreateOrUpdateProject from './components/createOrUpdateProject';
import { EntityDto } from '../../services/dto/entityDto';
import { L } from '../../lib/abpUtility';
import Stores from '../../stores/storeIdentifier';
import ProjectStore from '../../stores/projectStore';
import JobTitleStore from '../../stores/jobTitleStore';
import moment from 'moment';
import UpdateProjectInput from '../../services/project/dto/updateProjectInput';

export interface IProjectProps {
  projectStore: ProjectStore;
  jobTitleStore: JobTitleStore;
}

export interface IProjectState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  projectId: number;
  filter: string;
}

const confirm = Modal.confirm;
const Search = Input.Search;

@inject(Stores.ProjectStore)
@inject(Stores.JobTitleStore)
@observer
class Project extends AppComponentBase<IProjectProps, IProjectState> {
  formRef: any;

  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    projectId: 0,
    filter: '',
  };

  async componentDidMount() {
    await this.getAll();
  }

  async getAll() {
    await this.props.projectStore.getAll({ maxResultCount: this.state.maxResultCount, skipCount: this.state.skipCount, keyword: this.state.filter });
  }

  handleTableChange = (pagination: any) => {
    this.setState({ skipCount: (pagination.current - 1) * this.state.maxResultCount! }, async () => await this.getAll());
  };

  Modal = () => {
    this.setState({
      modalVisible: !this.state.modalVisible,
    });
  };

  async createOrUpdateModalOpen(entityDto: EntityDto) {
    if (entityDto.id === 0) {
      this.props.projectStore.createProject();
    } else {
      await this.props.projectStore.get(entityDto);
    }

    this.setState({ projectId: entityDto.id });
    this.Modal();

    if (entityDto.id !== 0) {
      this.formRef.props.form.setFieldsValue({
        id: this.props.projectStore.projectModel.id,
        name: this.props.projectStore.projectModel.name,
        startdate: moment(this.props.projectStore.projectModel.startdate),
        enddate: moment(this.props.projectStore.projectModel.enddate),
        cost: this.props.projectStore.projectModel.cost
      });
    } else {
      this.formRef.props.form.resetFields();
    }
  }

  delete(input: EntityDto) {
    const self = this;
    confirm({
      title: 'Do you Want to delete these items?',
      onOk() {
        self.props.projectStore.delete(input);
      },
      onCancel() {},
    });
  }

  handleCreate = () => {
    const form = this.formRef.props.form;
    form.validateFields(async (err: any, values: any) => {
      if (err) {
        return;
      } else {
        if (this.state.projectId === 0) {
          await this.props.projectStore.create(values);
        } else {

          var updateInfo: UpdateProjectInput = { id: this.state.projectId, ...values };
          if(updateInfo.enddate==null){
            updateInfo.enddate=undefined;
          }

          await this.props.projectStore.update(updateInfo);
        }
      }

      await this.getAll();
      this.setState({ modalVisible: false });
      form.resetFields();
    });
  };

  saveFormRef = (formRef: any) => {
    this.formRef = formRef;
  };

  handleSearch = (value: string) => {
    this.setState({ filter: value }, async () => await this.getAll());
  };

  public hashCode(str: string) { 
    var hash = 0;
    for (var i = 0; i < str.length; i++) {
       hash = str.charCodeAt(i) + ((hash << 5) - hash);
    }
    return hash;
  } 

  public intToRGB(i: number){
      var c = (i & 0x00FFFFFF)
          .toString(16)
          .toUpperCase();

      return "00000".substring(0, 6 - c.length) + c;
  }

  public render() {
    const { projects } = this.props.projectStore;
    const columns = [
      { title: L('Name'), dataIndex: 'name', key: 'name', width: 150, render: (text: string) => <div>{text}</div> },
      { title: L('Start Date'), dataIndex: 'startdate', key: 'startdate', width: 150, render: (text: string) => <div>{moment(text).format("MMMM Do, YYYY")}</div> },
      { title: L('End Date'), dataIndex: 'enddate', key: 'enddate', width: 150, render: (text: string) => 

      <div>{moment(text).isAfter(moment("0001-01-01")) ? moment(text).format("MMMM Do, YYYY") : "Ongoing"}</div> },

      { title: L('Base Cost'), dataIndex: 'cost', key: 'cost', width: 150, render: (text: string) => <div>{text}</div> },

      /* {
        title: L('Job'),
        dataIndex: 'jobTitleId',
        key: 'jobTitleId',
        width: 150,
        render: (text: boolean) => (text === true ? <Tag color="#2db7f5">{L('Yes')}</Tag> : <Tag color="red">{L('No')}</Tag>),
      }, */
      {
        title: L('Actions'),
        width: 150,
        render: (text: string, item: any) => (
          <div>
            <Dropdown
              trigger={['click']}
              overlay={
                <Menu>
                  <Menu.Item onClick={() => this.createOrUpdateModalOpen({ id: item.id })}>{L('Edit')}</Menu.Item>
                  <Menu.Item onClick={() => this.delete({ id: item.id })}>{L('Delete')}</Menu.Item>
                </Menu>
              }
              placement="bottomLeft"
            >
              <Button type="primary" icon="setting">
                {L('Actions')}
              </Button>
            </Dropdown>
          </div>
        ),
      },
    ];

    return (
      <Card>
        <Row>
          <Col
            xs={{ span: 4, offset: 0 }}
            sm={{ span: 4, offset: 0 }}
            md={{ span: 4, offset: 0 }}
            lg={{ span: 2, offset: 0 }}
            xl={{ span: 2, offset: 0 }}
            xxl={{ span: 2, offset: 0 }}
          >
            <h2>{L('Projects')}</h2>
          </Col>
          <Col
            xs={{ span: 14, offset: 0 }}
            sm={{ span: 15, offset: 0 }}
            md={{ span: 15, offset: 0 }}
            lg={{ span: 1, offset: 21 }}
            xl={{ span: 1, offset: 21 }}
            xxl={{ span: 1, offset: 21 }}
          >

          </Col>
          
        </Row>
        <Row className="searchbar-button">
          <Col sm={{ span: 10, offset: 0 }}>
            <Search placeholder={this.L('Filter')} onSearch={this.handleSearch} />
          </Col>
          <Col><Button type="primary"  icon="plus" onClick={() => this.createOrUpdateModalOpen({ id: 0 })}> {L('Add Project')} </Button></Col>
        </Row>
        <Row style={{ marginTop: 20 }}>
          <Col
            xs={{ span: 24, offset: 0 }}
            sm={{ span: 24, offset: 0 }}
            md={{ span: 24, offset: 0 }}
            lg={{ span: 24, offset: 0 }}
            xl={{ span: 24, offset: 0 }}
            xxl={{ span: 24, offset: 0 }}
          >
            <Table
              rowKey="id"
              size={'default'}
              bordered={true}
              pagination={{ pageSize: this.state.maxResultCount, total: projects === undefined ? 0 : projects.totalCount, defaultCurrent: 1 }}
              columns={columns}
              loading={projects === undefined ? true : false}
              dataSource={projects === undefined ? [] : projects.items}
              onChange={this.handleTableChange}
            />
          </Col>
        </Row>
        <CreateOrUpdateProject
          wrappedComponentRef={this.saveFormRef}
          visible={this.state.modalVisible}
          jobTitleStore= {this.props.jobTitleStore}
          onCancel={() =>
            this.setState({
              modalVisible: false,
            })
          }
          modalType={this.state.projectId === 0 ? 'edit' : 'create'}
          onCreate={this.handleCreate}
        />
      </Card>
    );
  }
}

export default Project;
