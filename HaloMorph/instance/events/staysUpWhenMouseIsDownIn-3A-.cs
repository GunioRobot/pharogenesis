staysUpWhenMouseIsDownIn: aMorph
	^ ((aMorph == target) or: [submorphs includes: aMorph]) or:
		["name under edit, special case"
		(aMorph isKindOf: StringMorphEditor) and: [submorphs includes: aMorph owner]]