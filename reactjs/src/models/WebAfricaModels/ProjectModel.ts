class ProjectModel {
  name!: string;
  startdate!: Date;
  enddate: Date | null | undefined;
  cost!: number;
  id!: number;
}

export default ProjectModel;
