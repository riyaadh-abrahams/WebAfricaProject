import { L } from '../../../lib/abpUtility';

const rules = {
  name: [{ required: true, message: L('ThisFieldIsRequired') }],
  startdate: [{ required: true, message: L('ThisFieldIsRequired') }],
  enddate: [{ required: true, message: L('ThisFieldIsRequired') }],
  cost: [{ required: true, message: L('ThisFieldIsRequired') }],
};

export default rules;
