primitiveExponent
	"Exponent part of this float."

	| rcvr frac pwr |
	self var: #rcvr declareC: 'double rcvr'.
	self var: #frac declareC: 'double frac'.
	rcvr _ self popFloat.
	successFlag
		ifTrue: [
			self cCode: 'frac = frexp(rcvr, &pwr)'.  "rcvr = frac * 2^pwr, where frac is in [0.5..1.0)"
			self pushInteger: pwr - 1]
		ifFalse: [self unPop: 1].