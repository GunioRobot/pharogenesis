changedSelectorsComparedTo: aTraitTransformation
	| selectors otherSelectors changedSelectors aliases otherAliases |
	selectors _ self allSelectors asIdentitySet.
	otherSelectors _ aTraitTransformation allSelectors asIdentitySet.
	changedSelectors _ IdentitySet withAll: (
		(selectors difference: otherSelectors) union: (otherSelectors difference: selectors)).
	aliases _ self allAliasesDict.
	otherAliases _ aTraitTransformation allAliasesDict.
	aliases keysAndValuesDo: [:key :value |
		(value ~~ (otherAliases at: key ifAbsent: [nil])) ifTrue: [changedSelectors add: key]].
	otherAliases keysAndValuesDo: [:key :value |
		(value ~~ (aliases at: key ifAbsent: [nil])) ifTrue: [changedSelectors add: key]].
	^ changedSelectors.