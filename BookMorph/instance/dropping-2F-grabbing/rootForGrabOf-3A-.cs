rootForGrabOf: aMorph

	| root |
	self dragNDropEnabled ifFalse: [^ super rootForGrabOf: aMorph].
	(aMorph = currentPage or: [aMorph owner = self])
		ifTrue: [^ self rootForGrabOf: self].

	root _ aMorph.
	[root = self] whileFalse:
		[root owner == currentPage ifTrue: [^ root].
		root _ root owner].
	^ super rootForGrabOf: aMorph