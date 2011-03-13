simulatedBackspace
	"Backspace over the last character, derived from hand-char recognition.  2/5/96 sw"

	| startIndex |
	startIndex := self markIndex + (self hasSelection ifTrue: [1] ifFalse: [0]).

	startIndex := 1 max: startIndex - 1.
	self backTo: startIndex.
	^ false