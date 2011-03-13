mouseDown: event onItem: aMorph

	event yellowButtonPressed ifTrue: [^ self yellowButtonActivity: event shiftPressed].
	aMorph ifNotNil: [
		self dragEnabled ifTrue: [aMorph highlightForMouseDown]
	]