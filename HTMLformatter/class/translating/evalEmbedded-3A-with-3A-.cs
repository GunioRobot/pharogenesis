evalEmbedded: stringOrStream with: request
	| sourceStream targetStream evalStream currentStream evalValue peekValue ch |
	(stringOrStream isKindOf: Stream)
		ifTrue: [sourceStream := stringOrStream]
		ifFalse: [sourceStream := ReadStream on: stringOrStream].
	targetStream := WriteStream on: String new.
	currentStream := targetStream. 
	[sourceStream atEnd] whileFalse: 
		[ch := sourceStream next.
		ch = $< ifTrue:
			[ peekValue := sourceStream peek. (peekValue = $?) ifTrue:
				[evalStream := WriteStream on: String new.
				currentStream := evalStream.
				sourceStream next. "Eat the ?"
				ch := sourceStream next.]].
		((currentStream = evalStream) and: [ch = $?]) ifTrue:
			[ peekValue := sourceStream peek. (peekValue = $>) ifTrue:
				[sourceStream next. "Eat the >"
				currentStream := targetStream.
				evalValue := (Compiler new evaluate: (evalStream contents) 
					in: thisContext to: self notifying: nil ifFail: [^nil]).
				(evalValue isKindOf: String)
				ifFalse: [evalValue := evalValue printString].
				currentStream nextPutAll: evalValue.]]
			ifFalse: [currentStream nextPut: ch].].
	^targetStream contents

