rootForGrabOf: aMorph

	| root |
	(openToDragNDrop or: [copyContents])
		ifFalse: [^ super rootForGrabOf: aMorph].
	(aMorph = currentPage or: [aMorph owner = self])
		ifTrue: [^ self rootForGrabOf: self].

	root _ aMorph.
	[root = self] whileFalse:
		[root owner == currentPage ifTrue:
			[(copyContents and: [openToDragNDrop not])
				ifTrue: [^ root fullCopy]
				ifFalse: [^ root]].
		root _ root owner].
	^ super rootForGrabOf: aMorph
