primitiveInstVarAt
	| index rcvr hdr fmt totalLength fixedFields value |
	index _ self stackIntegerValue: 0.
	rcvr _ self stackValue: 1.
	successFlag
		ifTrue: [hdr _ self baseHeader: rcvr.
			fmt _ hdr >> 8 bitAnd: 15.
			totalLength _ self lengthOf: rcvr baseHeader: hdr format: fmt.
			fixedFields _ self fixedFieldsOf: rcvr format: fmt length: totalLength.
			(index >= 1 and: [index <= fixedFields])
				ifFalse: [successFlag _ false]].
	successFlag ifTrue: [value _ self subscript: rcvr with: index format: fmt].
	successFlag ifTrue: [self pop: argumentCount + 1 thenPush: value]