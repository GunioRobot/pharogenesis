sizeInWordsOf: anObject
"NOTE: This is the new length of the object in LONG WORDS.
		Does not include the class (header) word."
	| class |
	class _ anObject class.
	class isBytes ifTrue: [^ anObject basicSize+3 // 4].
	class isBits ifTrue: [^ anObject basicSize].	"in two byte chunks"
	class isVariable ifTrue: [
		"terrible hack to get around contexts beleiving they are only sized up to the SP"
		(class = BlockContext or: [class = MethodContext])
			ifTrue:[^class instSize + CompiledMethod fullFrameSize].
		 ^ class instSize + anObject basicSize].
	^ class instSize