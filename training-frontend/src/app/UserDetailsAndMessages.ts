import {UserMessage} from './UserMessage';

export interface UserMessages{
  IsSuccess: boolean;
  Username: string;
  Messages?: [UserMessage];
}
