import * as React from 'react';

import { Form, Input, Modal, Select } from 'antd';

import { FormComponentProps } from 'antd/lib/form';
import FormItem from 'antd/lib/form/FormItem';
import { L } from '../../../lib/abpUtility';
import rules from './createOrUpdateEmployee.validation';
import JobTitleStore from '../../../stores/jobTitleStore';
import { inject } from 'mobx-react';
import Stores from '../../../stores/storeIdentifier';

export interface ICreateOrUpdateEmployeeProps extends FormComponentProps {
  visible: boolean;
  modalType: string;
  jobTitleStore: JobTitleStore;
  onCreate: () => void;
  onCancel: () => void;
}

export interface IJobTitleProps {
  
}

export interface IJobTitleState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  jobTitleId: number;
  filter: string;
}

@inject(Stores.JobTitleStore)
class CreateOrUpdateEmployee extends React.Component<ICreateOrUpdateEmployeeProps> {

  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    jobTitleId: 0,
    filter: '',
  };


  async componentDidMount() {
    await this.getAll();
  }

  async getAll() {
    await this.props.jobTitleStore.getAll({ maxResultCount: this.state.maxResultCount, skipCount: this.state.skipCount, keyword: this.state.filter });
  }


  render() {
    const { jobTitles } = this.props.jobTitleStore;
    const { Option } = Select;
    const formItemLayout = {
      labelCol: {
        xs: { span: 6 },
        sm: { span: 6 },
        md: { span: 6 },
        lg: { span: 6 },
        xl: { span: 6 },
        xxl: { span: 6 },
      },
      wrapperCol: {
        xs: { span: 18 },
        sm: { span: 18 },
        md: { span: 18 },
        lg: { span: 18 },
        xl: { span: 18 },
        xxl: { span: 18 },
      },
    };

    const tailFormItemLayout = {
      labelCol: {
        xs: { span: 6 },
        sm: { span: 6 },
        md: { span: 6 },
        lg: { span: 6 },
        xl: { span: 6 },
        xxl: { span: 6 },
      },
      wrapperCol: {
        xs: { span: 18 },
        sm: { span: 18 },
        md: { span: 18 },
        lg: { span: 18 },
        xl: { span: 18 },
        xxl: { span: 18 },
      },
    };

    const { getFieldDecorator } = this.props.form;
    const { visible, onCancel, onCreate } = this.props;

    var jobOptions = jobTitles === undefined ? [] : jobTitles.items.map((val, index) => {
      return (
        <Option value={val.id}>
          { val.jobTitleLabel }
        </Option>
      );
    })

    console.log(jobOptions);

    

    return (
      <Modal visible={visible} onCancel={onCancel} onOk={onCreate} title={L('Employees')} width={550}>
        <Form>
          <FormItem label={L('Name')} {...formItemLayout}>
            {getFieldDecorator('name', { rules: rules.name })(<Input />)}
          </FormItem>
          <FormItem label={L('Surname')} {...formItemLayout}>
            {getFieldDecorator('surname', { rules: rules.surname })(<Input />)}
          </FormItem>

{/*           {this.props.modalType === 'edit' ? (
            <FormItem label={L('DatabaseConnectionString')} {...formItemLayout}>
              {getFieldDecorator('connectionString')(<Input />)}
            </FormItem>
          ) : null} */}
          <FormItem label={L('Job Title')} {...tailFormItemLayout}>
            {getFieldDecorator('jobTitleId', {rules: rules.jobTitleId})(

            <Select style={{ width: 120 }}/*  onChange={handleChange} */>
             {jobOptions}
            
          </Select>

            
            )}
          </FormItem>

        </Form>
      </Modal>
    );
  }
}

export default Form.create<ICreateOrUpdateEmployeeProps>()(CreateOrUpdateEmployee);
