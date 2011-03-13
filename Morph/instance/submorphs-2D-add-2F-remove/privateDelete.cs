privateDelete
	"Remove the receiver as a submorph of its owner and make its new owner be nil, without informing anyone other than my owner"

	owner ifNotNil:
		[owner privateRemoveMorph: self.
		owner _ nil].