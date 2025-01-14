const { Schema, model } = require('mongoose');

const schema = new Schema({
    name: { type: String, required: true},
    description: { type: String, required: true, maxlength: 500},
    imageURL: { type: String, required: true, match: /^https?:\/\//},
    difficulty: { type: Number, min: 1, max: 6},
    accessories: [{type: Schema.Types.ObjectId, ref: 'Accessory'}],
    author: {type: Schema.Types.ObjectId, ref: 'User'}
});
module.exports = model('Cube', schema);