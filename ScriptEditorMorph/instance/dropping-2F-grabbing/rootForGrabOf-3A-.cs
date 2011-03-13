rootForGrabOf: aMorph
	"Allow TileMorphs to be extracted, and note that script has changed."

	| root |
	root _ aMorph.
	[root = self] whileFalse:
		[root isTileLike ifTrue:
			[self scriptEdited.
			^ root].
		root _ root owner].
	^ super rootForGrabOf: aMorph
