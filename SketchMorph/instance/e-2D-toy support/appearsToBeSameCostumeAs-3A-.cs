appearsToBeSameCostumeAs: aMorph

	(aMorph isKindOf: self class) ifFalse: [^false].
	^originalForm == aMorph form or: [
		originalForm appearsToBeSameCostumeAs: aMorph form
	]