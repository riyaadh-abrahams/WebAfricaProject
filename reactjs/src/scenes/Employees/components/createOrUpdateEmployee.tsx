import * as React from 'react';

import { Form, Input, Modal } from 'antd';

import { FormComponentProps } from 'antd/lib/form';
import FormItem from 'antd/lib/form/FormItem';
import { L } from '../../../lib/abpUtility';
import rules from './createOrUpdateEmployee.validation';

export interface ICreateOrUpdateEmployeeProps extends FormComponentProps {
  visible: boolean;
  modalType: string;
  onCreate: () => void;
  onCancel: () => void;
}

class CreateOrUpdateEmployee extends React.Component<ICreateOrUpdateEmployeeProps> {
  render() {
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
            {getFieldDecorator('jobTitleId', {rules: rules.jobTitleId})(<Input type="number"/>)}
          </FormItem>

        </Form>
      </Modal>
    );
  }
}

export default Form.create<ICreateOrUpdateEmployeeProps>()(CreateOrUpdateEmployee);
