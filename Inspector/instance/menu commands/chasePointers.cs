chasePointers
	| selected  saved |
	self selectionIndex == 0 ifTrue: [^ self changed: #flash].
	selected _ self selection.
	saved _ self object.
	[self object: nil.
	(Smalltalk includesKey: #PointerFinder)
		ifTrue: [PointerFinder on: selected]
		ifFalse: [self inspectPointers]]
		ensure: [self object: saved]