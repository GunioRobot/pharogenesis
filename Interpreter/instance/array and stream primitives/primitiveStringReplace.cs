primitiveStringReplace
	" 
	<array> primReplaceFrom: start to: stop with: replacement 
	startingAt: repStart  
	<primitive: 105>
	"
	| array start stop repl replStart hdr arrayFmt totalLength arrayInstSize replFmt replInstSize srcIndex |
	array _ self stackValue: 4.
	start _ self stackIntegerValue: 3.
	stop _ self stackIntegerValue: 2.
	repl _ self stackValue: 1.
	replStart _ self stackIntegerValue: 0.

	successFlag ifFalse: [^ self primitiveFail].
	(self isIntegerObject: repl) ifTrue: ["can happen in LgInt copy"
			^ self primitiveFail].

	hdr _ self baseHeader: array.
	arrayFmt _ hdr >> 8 bitAnd: 15.
	totalLength _ self lengthOf: array baseHeader: hdr format: arrayFmt.
	arrayInstSize _ self fixedFieldsOf: array format: arrayFmt length: totalLength.
	(start >= 1 and: [start - 1 <= stop and: [stop + arrayInstSize <= totalLength]])
		ifFalse: [^ self primitiveFail].

	hdr _ self baseHeader: repl.
	replFmt _ hdr >> 8 bitAnd: 15.
	totalLength _ self lengthOf: repl baseHeader: hdr format: replFmt.
	replInstSize _ self fixedFieldsOf: repl format: replFmt length: totalLength.
	(replStart >= 1 and: [stop - start + replStart + replInstSize <= totalLength])
		ifFalse: [^ self primitiveFail].

	"Array formats (without byteSize bits, if bytes array) must be same "
	arrayFmt < 8
		ifTrue: [arrayFmt = replFmt
				ifFalse: [^ self primitiveFail]]
		ifFalse: [(arrayFmt bitAnd: 12) = (replFmt bitAnd: 12)
				ifFalse: [^ self primitiveFail]].

	srcIndex _ replStart + replInstSize - 1.
	"- 1 for 0-based access"

	arrayFmt < 4
		ifTrue: ["pointer type objects"
			start + arrayInstSize - 1 to: stop + arrayInstSize - 1 do: [:i |
				self storePointer: i ofObject: array withValue: (self fetchPointer: srcIndex ofObject: repl).
					srcIndex _ srcIndex + 1]]
		ifFalse: [arrayFmt < 8
				ifTrue: ["long-word type objects"
					start + arrayInstSize - 1 to: stop + arrayInstSize - 1
						do: [:i | self storeWord: i ofObject: array withValue: (self fetchWord: srcIndex ofObject: repl).
							srcIndex _ srcIndex + 1]]
				ifFalse: ["byte-type objects"
					start + arrayInstSize - 1 to: stop + arrayInstSize - 1
						do: [:i |  self storeByte: i ofObject: array withValue: (self fetchByte: srcIndex ofObject: repl).
							srcIndex _ srcIndex + 1]]].
	"We might consider  comparing stop - start to some value here and using forceInterruptCheck"

	self pop: argumentCount "leave rcvr on stack"