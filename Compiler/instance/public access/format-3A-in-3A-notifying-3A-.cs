format: textOrStream in: aClass notifying: aRequestor
	"Compile a parse tree from the argument, textOrStream. Answer a string 
	containing the original code, formatted nicely.
	If the leftShift key is pressed, then decorate the resulting text with
	color and hypertext actions"
	| aNode |
	self from: textOrStream
		class: aClass
		context: nil
		notifying: aRequestor.
	aNode _ self format: sourceStream noPattern: false ifFail: [^nil].
	Sensor leftShiftDown
		ifTrue: [^ aNode decompileText]
		ifFalse: [^ aNode decompileString]