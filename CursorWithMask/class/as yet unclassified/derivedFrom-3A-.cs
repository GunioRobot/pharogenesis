derivedFrom: aForm      "Cursor initNormalWithMask.  Cursor normal show"
	"aForm is presumably a cursor"
	| cursor mask ext |
	ext _ aForm extent.
	cursor _ self extent: ext.
	cursor copy: (1@1 extent: ext) from: 0@0 in: aForm rule: Form over.
	mask _ Form extent: ext.
	(1@1) eightNeighbors do:
		[:p | mask copy: (p extent: ext) from: 0@0 in: aForm rule: Form under].
	cursor setMaskForm: mask.
	cursor offset: ((aForm offset - (1@1)) max: ext negated).
	^ cursor