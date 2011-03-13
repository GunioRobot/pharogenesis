setColumn: aColumn filter: aFilter
	self model: aColumn.
	list _ aColumn listMorph.
	self initGeometry.
	aFilter ifNotNil: [self addButton: aFilter buttonMorph].