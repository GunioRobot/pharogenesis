primitiveMakePoint
	| rcvr argument pt |
	argument _ self stackValue: 0.
	rcvr _ self stackValue: 1.
	(self isIntegerObject: rcvr) ifTrue:[
		(self isIntegerObject: argument)
			ifTrue:[pt _ self makePointwithxValue: (self integerValueOf: rcvr)
							yValue: (self integerValueOf: argument)]
			ifFalse:[pt _ self makePointwithxValue: (self integerValueOf: rcvr)
							yValue: 0.
					"Above may cause GC!"
					self storePointer: 1 ofObject: pt withValue: (self stackValue: 0)].
	] ifFalse:[
		(self isFloatObject: rcvr) ifFalse:[^self success: false].
		pt _ self makePointwithxValue: 0 yValue: 0.
		"Above may cause GC!"
		self storePointer: 0 ofObject: pt withValue: (self stackValue: 1).
		self storePointer: 1 ofObject: pt withValue: (self stackValue: 0).
	].
	self pop: 2.
	self push: pt.
