primitiveTruncated 
	| rcvr frac trunc |
	self var: #rcvr declareC: 'double rcvr'.
	self var: #frac declareC: 'double frac'.
	self var: #trunc declareC: 'double trunc'.
	rcvr _ self popFloat.
	successFlag ifTrue: [
		self cCode: 'frac = modf(rcvr, &trunc)'.
		self cCode: 'success((-1073741824.0 <= trunc) && (trunc <= 1073741823.0))'.
	].
	successFlag
		ifTrue: [self cCode: 'pushInteger((int) trunc)']
		ifFalse: [self unPop: 1]