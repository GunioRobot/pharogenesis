format: textOrStream in: aClass notifying: aRequestor contentsSymbol: aSymbol
	"Compile a parse tree from the argument, textOrStream. Answer a string containing the original code, formatted nicely.  If aBoolean is true, then decorate the resulting text with color and hypertext actions"

	| aNode |
	self from: textOrStream
		class: aClass
		context: nil
		notifying: aRequestor.
	aNode _ self format: sourceStream noPattern: false ifFail: [^ nil].

	aSymbol == #colorPrint
		ifTrue: [^ aNode asColorizedSmalltalk80Text].

	aSymbol == #altSyntax  "Alan's current explorations for alternate syntax - 2000/2001"
		ifTrue:
			[^ aNode asAltSyntaxText].

	^ aNode decompileString