staysUpWhenMouseIsDownIn: aMorph
	^ (aMorph == target) or: [submorphs includes: aMorph]