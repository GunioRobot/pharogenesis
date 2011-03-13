delete
	"Remove the receiver as a submorph of its owner and make its new owner be nil."

	| aWorld |
	owner ifNotNil:
		[costumee ifNotNil: [aWorld _ self world].
		owner privateRemoveMorph: self.
		owner _ nil.
		costumee ifNotNil: [costumee noteDeletionOf: self fromWorld: aWorld]].