printPatchSequence: ps on: aStream
	| type line attr |
	ps do:[:assoc|
		type := assoc key.
		line := assoc value.
		attr := TextEmphasis normal.
		type == #insert ifTrue:[attr := TextColor red].
		type == #remove ifTrue:[attr := TextEmphasis struckOut].
		aStream withAttribute: attr do:[aStream nextPutAll: line].
	].