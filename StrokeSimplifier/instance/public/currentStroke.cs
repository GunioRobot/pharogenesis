currentStroke
	"Return a copy of the current stroke.
	As far as we have it, that is."
	| pts |
	pts _ WriteStream on: (Array new: 100).
	firstPoint do:[:pt| pts nextPut: pt position].
	^pts contents