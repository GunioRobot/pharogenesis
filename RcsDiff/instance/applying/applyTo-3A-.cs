applyTo: aString
	"Apply me to given String and return the patched String."

	| space commandStream originalStream nextCommand nextLine lineCount currentLine |
	space := Character space.
	commandStream := ReadStream on: commandLines.
	originalStream := ReadStream on: aString.
	currentLine := 1.
	^String streamContents: [:stream |
		[nextCommand := commandStream next.
		nextCommand isNil] whileFalse: [ 
			nextLine := (commandStream upTo: space) asNumber.
			lineCount := commandStream nextLine asNumber.
			[currentLine = nextLine]
				whileFalse: [stream nextPutAll: originalStream nextLine; cr. currentLine := currentLine + 1].
			nextCommand = $d
				ifTrue:[ lineCount timesRepeat: [originalStream nextLine. currentLine := currentLine + 1]]
				ifFalse:[ nextCommand = $a
							ifTrue:[ stream nextPutAll: originalStream nextLine; cr.
									currentLine := currentLine + 1.
									lineCount timesRepeat: [
										stream nextPutAll: commandStream nextLine; cr]]]].
		stream nextPutAll: originalStream upToEnd]