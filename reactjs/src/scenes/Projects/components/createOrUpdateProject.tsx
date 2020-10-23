import * as React from 'react';

import { DatePicker, Form, Input, Modal, Select } from 'antd';

import { FormComponentProps } from 'antd/lib/form';
import FormItem from 'antd/lib/form/FormItem';
import { L } from '../../../lib/abpUtility';
import rules from './createOrUpdateProject.validation';
import JobTitleStore from '../../../stores/jobTitleStore';
import { inject } from 'mobx-react';
import Stores from '../../../stores/storeIdentifier';


export interface ICreateOrUpdateProjectProps extends FormComponentProps {
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
class CreateOrUpdateProject extends React.Component<ICreateOrUpdateProjectProps> {

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
      <Modal visible={visible} onCancel={onCancel} onOk={onCreate} title={L('Projects')} width={550}>
        <Form>
          <FormItem label={L('Name')} {...formItemLayout}>
            {getFieldDecorator('name', { rules: rules.name })(<Input />)}
          </FormItem>

          <FormItem label={L('Start Date')} {...formItemLayout}>
            {getFieldDecorator('startdate', { rules: rules.startdate })(
              <DatePicker />
            )}
          </FormItem>

          <FormItem label={L('End Date')} {...formItemLayout}>
            {getFieldDecorator('enddate', {  initialValue:undefined}, )(
              <DatePicker />
            )}
          </FormItem>

          <FormItem label={L('Cost')} {...formItemLayout}>
            {getFieldDecorator('cost', { rules: rules.cost })(<Input />)}
          </FormItem>

        </Form>
      </Modal>
    );
  }
}

export default Form.create<ICreateOrUpdateProjectProps>()(CreateOrUpdateProject);
