stSizeOf: oop
	"Return the number of indexable fields in the given object. (i.e., what Smalltalk would return for <obj> size)."
	"Note: Assume oop is not a SmallInteger!"

	| hdr fmt totalLength fixedFields |
	self inline: true.
	hdr _ self baseHeader: oop.
	fmt _ (hdr >> 8) bitAnd: 16rF.
	totalLength _ self lengthOf: oop baseHeader: hdr format: fmt.
	fixedFields _ self fixedFieldsOf: oop format: fmt length: totalLength.
	^ totalLength - fixedFields