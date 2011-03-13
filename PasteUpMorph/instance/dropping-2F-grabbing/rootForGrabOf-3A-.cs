rootForGrabOf: aMorph
	"If open to drag-n-drop, allow submorph to be extracted. If parts bin, copy the submorph."
	| root |
	root _ aMorph.
	[root = self] whileFalse:
		[root owner == self ifTrue:
			[self isPartsBin
				ifTrue:
					[^ root usableDuplicate].
			self openToDragNDrop
					ifTrue: [^ root]].
		root _ root owner].
	^ super rootForGrabOf: aMorph
