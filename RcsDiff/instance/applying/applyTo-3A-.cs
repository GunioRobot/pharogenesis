applyTo: aString
	"Apply me to given String and return the patched String."

	| space commandStream originalStream nextCommand nextLine lineCount currentLine |
	space _ Character space.
	commandStream _ ReadStream on: commandLines.
	originalStream _ ReadStream on: aString.
	currentLine _ 1.
	^String streamContents: [:stream |
		[nextCommand _ commandStream next.
		nextCommand isNil] whileFalse: [ 
			nextLine _ (commandStream upTo: space) asNumber.
			lineCount _ commandStream nextLine asNumber.
			[currentLine = nextLine]
				whileFalse: [stream nextPutAll: originalStream nextLine; cr. currentLine _ currentLine + 1].
			nextCommand = $d
				ifTrue:[ lineCount timesRepeat: [originalStream nextLine. currentLine _ currentLine + 1]]
				ifFalse:[ nextCommand = $a
							ifTrue:[ stream nextPutAll: originalStream nextLine; cr.
									currentLine _ currentLine + 1.
									lineCount timesRepeat: [
										stream nextPutAll: commandStream nextLine; cr]]]].
		stream nextPutAll: originalStream upToEnd]