primitiveInstVarAtPut

	| newValue index rcvr hdr fmt totalLength fixedFields |
	newValue _ self popStack.
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
		ifTrue: [self subscript: rcvr with: index storing: newValue format: fmt].
	successFlag
		ifTrue: [self push: newValue]
		ifFalse: [self unPop: 3]