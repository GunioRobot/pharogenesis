primitiveInstVarAt

	| index rcvr hdr fmt totalLength fixedFields value |
	index _ self popInteger.
	rcvr _ self popStack.
	successFlag ifTrue: [
		hdr _ self baseHeader: rcvr.
		fmt _ (hdr >> 8) bitAnd: 16rF.
		totalLength _ self lengthOf: rcvr baseHeader: hdr format: fmt.
		fixedFields _ self fixedFieldsOf: rcvr format: fmt length: totalLength.
		((index >= 1) and: [index <= fixedFields])
			ifFalse: [successFlag _ false]].
	successFlag
		ifTrue: [value _ self subscript: rcvr with: index format: fmt].
	successFlag
		ifTrue: [self push: value]
		ifFalse: [self unPop: 2]