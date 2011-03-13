backspace: characterStream 
	"Backspace over the last character."

	| startIndex |
	characterStream isEmpty
		ifTrue:
			[startIndex _ startBlock stringIndex +
				(startBlock = stopBlock ifTrue: [0] ifFalse: [1]).
			[sensor keyboardPressed and:
			 [sensor keyboardPeek asciiValue = 8]] whileTrue: [
				"process multiple backspaces"
				sensor keyboard.
				startIndex _ 1 max: startIndex - 1.
			].
			self backTo: startIndex]
		ifFalse:
			[sensor keyboard.
			characterStream skip: -1].
	^false