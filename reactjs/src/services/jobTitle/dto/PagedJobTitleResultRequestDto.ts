import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedJobTitleResultRequestDto extends PagedFilterAndSortedRequest  {
    keyword: string
}
