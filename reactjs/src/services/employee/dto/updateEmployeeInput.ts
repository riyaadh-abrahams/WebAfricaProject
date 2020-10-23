import JobTitleModel from '../../../models/WebAfricaModels/JobTitleModel';

export default interface UpdateEmployeeInput {
  name: string;
  surname: string;
  jobTitleId: number;
  id: number;
  jobTitle: JobTitleModel;
  dateOfBirth: Date;
}
