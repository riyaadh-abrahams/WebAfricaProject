export default interface UpdateProjectInput {
  name: string;
  startdate: Date;
  enddate: Date | undefined;
  cost: number;
  id: number;
}
