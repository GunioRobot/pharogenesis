rootForGrabOf: aMorph
	"If open to drag-n-drop, allow submorph to be extracted. Otherwise, copy the submorph."

	| root |

	root _ aMorph.
	[root = self] whileFalse:
		[root owner = self ifTrue:
			[^ openToDragNDrop
				ifTrue: [root]
				ifFalse: [root fullCopy removeProperty: #partsDonor]].
		root _ root owner].
	^ super rootForGrabOf: aMorph
