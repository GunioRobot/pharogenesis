backspace: characterStream 
	"Backspace over the last character."

	| startIndex |
	sensor leftShiftDown ifTrue: [^ self backWord: characterStream].

	startIndex := self markIndex + (self hasCaret ifTrue: [0] ifFalse: [1]).
	[sensor keyboardPressed and:
			 [sensor keyboardPeek asciiValue = 8]] whileTrue: [
				"process multiple backspaces"
				sensor keyboard.
				startIndex := 1 max: startIndex - 1.
			].
	self backTo: startIndex.
		
	^false