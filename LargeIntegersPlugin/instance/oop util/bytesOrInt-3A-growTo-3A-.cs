bytesOrInt: oop growTo: len 
	"Attention: this method invalidates all oop's! Only newBytes is valid at return."
	| newBytes val class |
	(interpreterProxy isIntegerObject: oop)
		ifTrue: 
			[val _ interpreterProxy integerValueOf: oop.
			val < 0
				ifTrue: [class _ interpreterProxy classLargeNegativeInteger]
				ifFalse: [class _ interpreterProxy classLargePositiveInteger].
			newBytes _ interpreterProxy instantiateClass: class indexableSize: len.
			self cCopyIntVal: val toBytes: newBytes]
		ifFalse: [newBytes _ self bytes: oop growTo: len].
	^ newBytes