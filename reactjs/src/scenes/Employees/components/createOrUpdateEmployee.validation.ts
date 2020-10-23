import { L } from '../../../lib/abpUtility';

const rules = {
  name: [{ required: true, message: L('ThisFieldIsRequired') }],
  surname: [{ required: true, message: L('ThisFieldIsRequired') }],
  jobTitleId: [{ required: true, message: L('ThisFieldIsRequired') }],
  dateOfBirth: [{ required: true, message: L('ThisFieldIsRequired') }],
};

export default rules;
