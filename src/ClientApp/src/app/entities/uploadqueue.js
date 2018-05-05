"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var guid_1 = require("../entities/guid");
/**
 * Represents an UploadQueue
 */
var UploadQueue = /** @class */ (function () {
    function UploadQueue(file) {
        this.file = file;
        this.progress = 0;
        this.id = guid_1.Guid.newGuid();
        this.message = '';
        this.isCancel = false;
        this.isError = false;
    }
    Object.defineProperty(UploadQueue.prototype, "isSuccess", {
        get: function () {
            if (this.progress == 100)
                return true;
            return false;
        },
        enumerable: true,
        configurable: true
    });
    ;
    return UploadQueue;
}());
exports.UploadQueue = UploadQueue;
//# sourceMappingURL=uploadqueue.js.map