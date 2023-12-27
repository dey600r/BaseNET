"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
class Server {
    constructor(hostname, port) {
        this.app = (0, express_1.default)();
        this.hostName = hostname;
        this.port = port;
    }
    start(callback) {
        this.app.listen(this.port, this.hostName, callback);
    }
}
exports.default = Server;
//# sourceMappingURL=server.js.map