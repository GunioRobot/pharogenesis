readFrom: aStream elementReader: aBlock
	| name items |
	categories _ Dictionary new: 64.
	aStream binary.
	[aStream atEnd]
		whileFalse:
			[name _ aStream nextString.
			items _ self newCategory.
			items readFrom: aStream elementReader: aBlock.
			categories at: name put: items].