primitiveInstVarAtPut
	| newValue index rcvr hdr fmt totalLength fixedFields |
	newValue _ self stackTop.
	index _ self stackIntegerValue: 1.
	rcvr _ self stackValue: 2.
	successFlag
		ifTrue: [hdr _ self baseHeader: rcvr.
			fmt _ hdr >> 8 bitAnd: 15.
			totalLength _ self lengthOf: rcvr baseHeader: hdr format: fmt.
			fixedFields _ self fixedFieldsOf: rcvr format: fmt length: totalLength.
			(index >= 1 and: [index <= fixedFields]) ifFalse: [successFlag _ false]].
	successFlag ifTrue: [self subscript: rcvr with: index storing: newValue format: fmt].
	successFlag ifTrue: [self pop: argumentCount + 1 thenPush: newValue]