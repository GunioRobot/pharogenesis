firstIndexableField: oop

	| hdr fmt totalLength fixedFields |
	self returnTypeC:'void *'.
	hdr _ self baseHeader: oop.
	fmt _ (hdr >> 8) bitAnd: 16rF.
	totalLength _ self lengthOf: oop baseHeader: hdr format: fmt.
	fixedFields _ self fixedFieldsOf: oop format: fmt length: totalLength.
	fmt < 8
		ifTrue:["32 bit field objects"
			^ self cCoerce: oop+4+ (fixedFields << 2) to:'void *']
		ifFalse:["Byte objects"
			^ self cCoerce: oop+4+fixedFields to:'void *']