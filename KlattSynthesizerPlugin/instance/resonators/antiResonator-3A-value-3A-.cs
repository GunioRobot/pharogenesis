antiResonator: index value: aFloat
	| answer p1 |
	self inline: true.
	self returnTypeC: 'float'.
	self var: 'aFloat' declareC: 'double aFloat'.
	self var: 'answer' declareC: 'double answer'.
	self var: 'p1' declareC: 'double p1'.
	answer _ (self resonatorA: index) * aFloat
			+ ((self resonatorB: index) * (p1 _ self resonatorP1: index))
			+ ((self resonatorC: index) * (self resonatorP2: index)).
	self resonatorP2: index put: p1.
	self resonatorP1: index put: aFloat.
	^ answer