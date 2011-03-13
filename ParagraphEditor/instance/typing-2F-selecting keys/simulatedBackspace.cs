simulatedBackspace
	"Backspace over the last character, derived from hand-char recognition.  2/5/96 sw"

	| startIndex |
	startIndex _ startBlock stringIndex + (startBlock = stopBlock ifTrue: [0] ifFalse: [1]).

	startIndex _ 1 max: startIndex - 1.
	self backTo: startIndex.
	^ false