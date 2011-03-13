backspace: characterStream 
	"Backspace over the last character."

	| startIndex |
	Sensor leftShiftDown ifTrue: [^ self backWord: characterStream].
	characterStream isEmpty
		ifTrue:
			[startIndex := self markIndex + (self hasCaret ifTrue: [0] ifFalse: [1]).
			startIndex := 1 max: startIndex - 1.
			self backTo: startIndex]
		ifFalse:
			[characterStream skip: -1].
	^false