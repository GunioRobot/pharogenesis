rootForGrabOf: aMorph

	| root |
	openToDragNDrop ifFalse: [^ super rootForGrabOf: aMorph].
	root _ aMorph.
	[root == self] whileFalse:
		[root owner = self ifTrue: [^ root].
		root _ root owner].
	^ super rootForGrabOf: aMorph
