withSuccessorsDo: aBlock
	"Evaluate aBlock for each morph in my successor chain"
	| each |
	each _ self.
	[each == nil]
		whileFalse: [aBlock value: each.
					each _ each successor]