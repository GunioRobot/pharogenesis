runsAndValuesDo: aBlock
	"Evaluate aBlock with the length and value of each run in the receiver"
	| basicValue length value |
	1 to: self basicSize do:[:i|
		basicValue _ self basicAt: i.
		length _ basicValue bitShift: -16.
		value _ basicValue bitAnd: 16rFFFF.
		value _ (value bitAnd: 16r7FFF) - (value bitAnd: 16r8000).
		aBlock value: length value: value.
	].