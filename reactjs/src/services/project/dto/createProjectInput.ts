export default class CreateProjectInput {
  name!: string;
  startdate!: Date;
  enddate!: Date | undefined | null;
  cost!: number;
  totalCost!: number;
}