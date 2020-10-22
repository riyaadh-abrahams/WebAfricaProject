import CreateJobTitleInput from './dto/createJobTitleInput';
import CreateJobTitleOutput from './dto/createJobTitleOutput';
import { EntityDto } from '../../services/dto/entityDto';
import { GetAllJobTitleOutput } from './dto/getAllJobTitleOutput';
import GetJobTitleOutput from './dto/getJobTitleOutput';
import { PagedResultDto } from '../../services/dto/pagedResultDto';
import {PagedJobTitleResultRequestDto} from './dto/PagedJobTitleResultRequestDto';
import UpdateJobTitleInput from './dto/updateJobTitleInput';
import UpdateJobTitleOutput from './dto/updateJobTitleOutput';
import http from '../httpService';

class JobTitleService {
  public async create(createJobTitleInput: CreateJobTitleInput): Promise<CreateJobTitleOutput> {
    let result = await http.post('api/services/app/JobTitleService/Create', createJobTitleInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/JobTitleService/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetJobTitleOutput> {
    let result = await http.get('api/services/app/JobTitleService/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(pagedFilterAndSortedRequest: PagedJobTitleResultRequestDto): Promise<PagedResultDto<GetAllJobTitleOutput>> {
    let result = await http.get('api/services/app/JobTitleService/GetAll', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }

  public async update(updateJobTitleInput: UpdateJobTitleInput): Promise<UpdateJobTitleOutput> {
    let result = await http.put('api/services/app/JobTitleService/Update', updateJobTitleInput);
    return result.data.result;
  }
}

export default new JobTitleService();
