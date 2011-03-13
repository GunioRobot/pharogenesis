mouseLeaveDragging: evt

"Transcript cr; print: self; show: ' leaveDragging'."
	self isBlockNode ifTrue:
		[self stopStepping; removeDropZones.
		(self firstOwnerSuchThat: [:m | m isSyntaxMorph and: [m isBlockNode]])
			ifNotNilDo: [:m | "Activate outer block."
						m startStepping]].

	"Move drop highlight back out a level"
	self unhighlight.
	(owner ~~ nil and: [owner isSyntaxMorph])
		ifTrue: [owner highlightForDrop: evt].

