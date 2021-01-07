import {UserMessage} from './UserMessage';

export interface UserDetailsAndMessages{
  IsSuccess: boolean;
  username: string;
  Messages?: [UserMessage];
}
