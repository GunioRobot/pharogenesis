antiResonator: index value: aFloat
	| answer p1 |
	answer := (self resonatorA: index) * aFloat
			+ ((self resonatorB: index) * (p1 := self resonatorP1: index))
			+ ((self resonatorC: index) * (self resonatorP2: index)).
	self resonatorP2: index put: p1.
	self resonatorP1: index put: aFloat.
	^ answer