writeContext: aContext
	"Nil out any garbage above the stack pointer to avoid a crash."
	| wordLength length |
	aContext stackPtr == nil ifFalse:
		[aContext stackPtr+1 to: aContext size do: [:ind | aContext at: ind put: nil]].
	"writing out a context is made more complicated as of sq2.3 by the change in the size primitive to return the stackpointer instead of the number of indexable slots.
	Thus the length parameter needs to be 
		BlockContext instSize + CompiledMethod fullFrameSize = 38
	while the trace block must only trace the first (named + sp) slots and the write block must add nulls after the sp."
	wordLength _ self sizeInWordsOf: aContext.
	length _ BlockContext instSize + aContext basicSize.
	self new: aContext
		class: aContext class
		length: wordLength
		trace: [1 to: length do: [:i | self trace: (aContext instVarAt: i)]]
		write: [ 1 to: length do: [:i | self writePointerField: (aContext instVarAt: i)].
			length + 1 to: wordLength do:[:i | self writePointerField: 0] ]