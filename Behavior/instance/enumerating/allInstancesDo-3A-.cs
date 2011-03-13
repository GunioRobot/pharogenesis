allInstancesDo: aBlock 
	"Evaluate the argument, aBlock, for each of the current instances of the 
	receiver."
	| inst next |
	self ==  UndefinedObject ifTrue: [^ aBlock value: nil].
	inst _ self someInstance.
	[inst == nil]
		whileFalse:
		[aBlock value: inst.
		inst _ inst nextInstance]