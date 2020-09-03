"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Quotation = void 0;
var Quotation = /** @class */ (function () {
    function Quotation() {
        this.categories = {};
        this.totalValue = 0;
    }
    Quotation.prototype.setSelectedItems = function (items) {
        var _this = this;
        items.forEach(function (item) {
            _this.addItem(item);
        });
    };
    Quotation.prototype.addItem = function (item) {
        if (this.categories[item.categordyId] == null || this.categories[item.categordyId] == undefined) {
            this.categories[item.categordyId] = [];
        }
        this.categories[item.categordyId].push(item);
        this.totalValue = this.totalValue + item.value;
    };
    Quotation.prototype.removeItem = function (item) {
        if (!this.categories[item.categordyId] == null && !this.categories[item.categordyId] == undefined) {
            var index = this.categories[item.categordyId].indexOf(item, 0);
            this.categories[item.categordyId].splice(index, 1);
        }
    };
    return Quotation;
}());
exports.Quotation = Quotation;
//# sourceMappingURL=Quotation.js.map