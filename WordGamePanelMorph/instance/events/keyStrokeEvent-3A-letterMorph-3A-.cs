keyStrokeEvent: evt letterMorph: morph 
	"Handle typing.  Calls keyCharacter:atIndex:nextFocus: for further behavior."

	| affectedMorph keyCharacter nextFocus |
	evt keyCharacter = Character backspace 
		ifTrue: 
			["<delete> zaps the current selection if there has been no typing,
				but it zaps the previous selection if there has been prior typing."

			affectedMorph := haveTypedHere 
						ifTrue: [morph previousTypeableLetter]
						ifFalse: [morph]. 
			keyCharacter := Character space.
			nextFocus := morph previousTypeableLetter]
		ifFalse: 
			[affectedMorph := morph.
			keyCharacter := evt keyCharacter asUppercase.
			(keyCharacter isLetter or: [keyCharacter = Character space]) 
				ifFalse: [^self].
			haveTypedHere := true.
			nextFocus := morph nextTypeableLetter.
			nextFocus == morph 
				ifTrue: 
					["If hit end of a word, change backspace mode"

					haveTypedHere := false]].
	evt hand newKeyboardFocus: nextFocus.
	self unhighlight.
	nextFocus color: Color green.
	self 
		keyCharacter: keyCharacter
		atIndex: affectedMorph indexInQuote
		nextFocus: nextFocus