cDigitOfCSI: csi at: ix 
	"Answer the value of an indexable field in the receiver.              
	LargePositiveInteger uses bytes of base two number, and each is a       
	      'digit' base 256."
	"ST indexed!"
	ix < 0 ifTrue: [interpreterProxy primitiveFail].
	ix > 4 ifTrue: [^ 0].
	csi < 0
		ifTrue: 
			[self cCode: ''
				inSmalltalk: [csi = -1073741824 ifTrue: ["SmallInteger minVal"
						"Can't negate minVal -- treat specially"
						^ #(0 0 0 64 ) at: ix]].
			^ (0 - csi bitShift: 1 - ix * 8)
				bitAnd: 255]
		ifFalse: [^ (csi bitShift: 1 - ix * 8)
				bitAnd: 255]