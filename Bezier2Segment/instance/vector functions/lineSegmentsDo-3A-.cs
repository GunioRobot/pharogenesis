lineSegmentsDo: aBlock
	"Evaluate aBlock with the receiver's line segments"
	"Note: We could use forward differencing here."
	| steps last deltaStep t next |
	steps _ 1 max: (self length // 10). "Assume 10 pixels per step"
	last _ start.
	deltaStep _ 1.0 / steps asFloat.
	t _ deltaStep.
	1 to: steps do:[:i|
		next _ self valueAt: t.
		aBlock value: last value: next.
		last _ next.
		t _ t + deltaStep].