import './index.less';
import * as React from 'react';

import { Button, Card, Col, Dropdown, Input, Menu, Modal, Row, Table, Tag, /* Tag */ } from 'antd';
import { inject, observer } from 'mobx-react';

import AppComponentBase from '../../components/AppComponentBase';
import CreateOrUpdateEmployee from './components/createOrUpdateEmployee';
import { EntityDto } from '../../services/dto/entityDto';
import { L } from '../../lib/abpUtility';
import Stores from '../../stores/storeIdentifier';
import EmployeeStore from '../../stores/employeeStore';
import JobTitleStore from '../../stores/jobTitleStore';
import moment from 'moment';

export interface IEmployeeProps {
  employeeStore: EmployeeStore;
  jobTitleStore: JobTitleStore;
}

export interface IEmployeeState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  employeeId: number;
  filter: string;
}

const confirm = Modal.confirm;
const Search = Input.Search;

@inject(Stores.EmployeeStore)
@inject(Stores.JobTitleStore)
@observer
class Employee extends AppComponentBase<IEmployeeProps, IEmployeeState> {
  formRef: any;

  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    employeeId: 0,
    filter: '',
  };

  async componentDidMount() {
    await this.getAll();
  }

  async getAll() {
    await this.props.employeeStore.getAll({ maxResultCount: this.state.maxResultCount, skipCount: this.state.skipCount, keyword: this.state.filter });
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
      this.props.employeeStore.createEmployee();
    } else {
      await this.props.employeeStore.get(entityDto);
    }

    this.setState({ employeeId: entityDto.id });
    this.Modal();

    if (entityDto.id !== 0) {
      this.formRef.props.form.setFieldsValue({
        id: this.props.employeeStore.employeeModel.id,
        name: this.props.employeeStore.employeeModel.name,
        surname: this.props.employeeStore.employeeModel.surname,
        jobTitleId: this.props.employeeStore.employeeModel.jobTitleId,
        jobTitle: this.props.employeeStore.employeeModel.jobTitle,
        dateOfBirth: moment(this.props.employeeStore.employeeModel.dateOfBirth)
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
        self.props.employeeStore.delete(input);
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
        if (this.state.employeeId === 0) {
          await this.props.employeeStore.create(values);
        } else {
          await this.props.employeeStore.update({ id: this.state.employeeId, ...values });
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
    const { employees } = this.props.employeeStore;
    const columns = [
      { title: L('Name'), dataIndex: 'name', key: 'name', width: 150, render: (text: string) => <div>{text}</div> },
      { title: L('Surname'), dataIndex: 'surname', key: 'surname', width: 150, render: (text: string) => <div>{text}</div> },
      { title: L('Date of Birth'), dataIndex: 'dateOfBirth', key: 'dateOfBirth', width: 150, render: (text: string) => <div>{moment(text).format("MMMM Do, YYYY")}</div> },
      { title: L('Job Title'), dataIndex: 'jobTitle.jobTitleLabel', key: 'obTitle.jobTitleLabel', 
        width: 150, render: (text: string) => <Tag color="#5c6976">{ text }</Tag> },
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
            <h2>{L('Employees')}</h2>
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
          <Col><Button type="primary"  icon="plus" onClick={() => this.createOrUpdateModalOpen({ id: 0 })}> {L('Add Employee')} </Button></Col>
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
              pagination={{ pageSize: this.state.maxResultCount, total: employees === undefined ? 0 : employees.totalCount, defaultCurrent: 1 }}
              columns={columns}
              loading={employees === undefined ? true : false}
              dataSource={employees === undefined ? [] : employees.items}
              onChange={this.handleTableChange}
            />
          </Col>
        </Row>
        <CreateOrUpdateEmployee
          wrappedComponentRef={this.saveFormRef}
          visible={this.state.modalVisible}
          jobTitleStore= {this.props.jobTitleStore}
          onCancel={() =>
            this.setState({
              modalVisible: false,
            })
          }
          modalType={this.state.employeeId === 0 ? 'edit' : 'create'}
          onCreate={this.handleCreate}
        />
      </Card>
    );
  }
}

export default Employee;
