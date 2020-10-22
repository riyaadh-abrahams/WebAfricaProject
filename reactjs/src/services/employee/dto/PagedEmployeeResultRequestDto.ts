import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedEmployeeResultRequestDto extends PagedFilterAndSortedRequest  {
    keyword: string
}
