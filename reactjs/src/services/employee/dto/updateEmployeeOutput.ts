import JobTitleModel from '../../../models/WebAfricaModels/JobTitleModel';

export default interface UpdateEmployeeOutput {
  name: string;
  surname: string;
  jobTitleId: number;
  jobTitle: JobTitleModel;
  id: number;
}
