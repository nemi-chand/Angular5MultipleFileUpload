import { Guid } from '../entities/guid';

/**
 * Represents an UploadQueue
 */
export class UploadQueue {
  id: string;
  file: File;
  progress: number;
  message: string;
  isCancel: boolean;
  isError: boolean;
  get isSuccess(): boolean {
    if (this.progress == 100)
      return true;

    return false;
  };

  constructor(file: File) {
    this.file = file;
    this.progress = 0;
    this.id = Guid.newGuid();
    this.message = '';
    this.isCancel = false;
    this.isError = false;
  }
}
