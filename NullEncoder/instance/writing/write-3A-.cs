write:anObject
	filterSelector  ifNil:[filterSelector_self class filterSelector].
	anObject ifNotNil: [anObject perform:filterSelector with:self].
