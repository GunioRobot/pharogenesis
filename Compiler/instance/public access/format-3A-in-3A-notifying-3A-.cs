format: textOrStream in: aClass notifying: aRequestor
	"Compile a parse tree from the argument, textOrStream. Answer a string 
	containing the original code, formatted nicely."

	| aNode |
	self from: textOrStream
		class: aClass
		context: nil
		notifying: aRequestor.
	aNode _ self format: sourceStream noPattern: false ifFail: [^nil].
	^aNode decompileString