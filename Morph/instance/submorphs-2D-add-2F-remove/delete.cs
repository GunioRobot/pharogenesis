delete
	"Remove the receiver as a submorph of its owner and make its new owner be nil."

	| aWorld |
	aWorld _ self world.
	owner ifNotNil:
		[owner privateRemoveMorph: self.
		owner _ nil.
		aWorld ifNotNil: [aWorld noteDeletionOf: self]].