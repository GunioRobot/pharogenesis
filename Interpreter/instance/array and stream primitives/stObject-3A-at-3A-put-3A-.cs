stObject: array at: index put: value
	"Do what ST would return for <obj> at: index put: value."

	| hdr fmt totalLength fixedFields |
	self inline: false.
	hdr _ self baseHeader: array.
	fmt _ (hdr >> 8) bitAnd: 16rF.
	totalLength _ self lengthOf: array baseHeader: hdr format: fmt.
	fixedFields _ self fixedFieldsOf: array format: fmt length: totalLength.
	((index >= 1) and: [index <= (totalLength - fixedFields)]) ifFalse: [successFlag _ false].
	successFlag ifTrue:
		[self subscript: array with: (index + fixedFields) storing: value format: fmt].
