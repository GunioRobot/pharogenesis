positionVertically

	| w |
	w _ self world ifNil: [^self].
	self top < w top ifTrue: [self top: w top].
	self bottom > w bottom ifTrue: [self bottom: w bottom].