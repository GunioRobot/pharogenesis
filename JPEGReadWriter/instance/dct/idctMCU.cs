idctMCU

	| comp fp ci |
	fp _ self useFloatingPoint.
	1 to: mcuMembership size do:[:i|
		ci _ mcuMembership at: i.
		comp _ currentComponents at: ci.
		fp ifTrue:[
			self idctBlockFloat: (mcuSampleBuffer at: i) component: comp.
		] ifFalse:[
			self primIdctInt: (mcuSampleBuffer at: i)
				qt: (qTable at: comp qTableIndex)]].