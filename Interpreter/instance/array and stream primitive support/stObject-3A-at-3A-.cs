stObject: array at: index
	"Return what ST would return for <obj> at: index."

	| hdr fmt totalLength fixedFields stSize |
	self inline: false.
	hdr _ self baseHeader: array.
	fmt _ (hdr >> 8) bitAnd: 16rF.
	totalLength _ self lengthOf: array baseHeader: hdr format: fmt.
	fixedFields _ self fixedFieldsOf: array format: fmt length: totalLength.
	(fmt = 3 and: [self isContextHeader: hdr])
		ifTrue: [stSize _ self fetchStackPointerOf: array]
		ifFalse: [stSize _ totalLength - fixedFields].
	((self cCoerce: index to: 'unsigned ') >= 1
		and: [(self cCoerce: index to: 'unsigned ') <= (self cCoerce: stSize to: 'unsigned ')])
		ifTrue: [^ self subscript: array with: (index + fixedFields) format: fmt]
		ifFalse: [successFlag _ false.  ^ 0].