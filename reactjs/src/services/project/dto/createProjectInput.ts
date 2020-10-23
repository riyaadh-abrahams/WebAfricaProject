export default class CreateProjectInput {
  name!: string;
  startdate!: Date;
  enddate!: Date | null | undefined;
  cost!: number;
}