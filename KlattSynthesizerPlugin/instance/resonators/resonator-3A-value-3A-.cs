resonator: index value: aFloat
	| answer p1 |
	self inline: true.
	self returnTypeC: 'float'.
	self var: 'aFloat' declareC: 'float aFloat'.
	self var: 'answer' declareC: 'float answer'.
	self var: 'p1' declareC: 'float p1'.
	answer _ (self resonatorA: index) * aFloat
			+ ((self resonatorB: index) * (p1 _ self resonatorP1: index))
			+ ((self resonatorC: index) * (self resonatorP2: index)).
	"(p1 between: -100000 and: 100000) ifFalse: [self halt].
	(answer between: -100000 and: 100000) ifFalse: [self halt]."
	self resonatorP2: index put: p1.
	self resonatorP1: index put: answer.
	^ answer