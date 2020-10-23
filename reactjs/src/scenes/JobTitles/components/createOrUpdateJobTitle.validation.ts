import { L } from '../../../lib/abpUtility';

const rules = {
  jobTitle: [{ required: true, message: L('ThisFieldIsRequired') }],
  extraProjectCosts: [{ required: true, message: L('ThisFieldIsRequired') }]
};

export default rules;
