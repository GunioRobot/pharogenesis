mpeg3tValueOf: mpeg3tHandle 
	"Return a pointer to the first byte of of the mpeg3_t record within the  
	given Smalltalk object, or nil if socketOop is not a mpeg3_t record."
	| index check |

	self returnTypeC: 'mpeg3_t *'.
	self var: #index declareC: 'mpeg3_t ** index'.
	interpreterProxy success: ((interpreterProxy isBytes: mpeg3tHandle)
			and: [(interpreterProxy byteSizeOf: mpeg3tHandle)
					= 4]).
	interpreterProxy failed
		ifTrue: [^ nil]
		ifFalse: 
			[index _ self cCoerce: (interpreterProxy firstIndexableField: mpeg3tHandle)
						to: 'mpeg3_t **'.
			self cCode: 'check = checkFileEntry(*index)'.
			check = 0 ifTrue: [^nil]. 
			^ self cCode: '*index']