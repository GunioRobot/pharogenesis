idctMCU

	| comp |
	self useFloatingPoint
		ifTrue:
			[mcuMembership withIndexDo:
				[:ci :i |
				comp _ currentComponents at: ci.
				self idctBlockFloat: (mcuSampleBuffer at: i) component: comp]]
		ifFalse:
			[mcuMembership withIndexDo:
				[:ci :i |
				comp _ currentComponents at: ci.
				self idctBlockInt: (mcuSampleBuffer at: i) component: comp]]
