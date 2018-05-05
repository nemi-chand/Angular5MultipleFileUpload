import { UploadQueue } from '../entities/uploadqueue';

export class Uploader {
  queue: UploadQueue[];

  constructor() {
    this.queue = [];
  }
}
