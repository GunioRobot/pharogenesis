addCostumeSpecificCategoriesTo: aCategoryList
	(self referent isKindOf: PaintBoxMorph)
			ifTrue:	[aCategoryList addIfNotPresent: 'paintbox']
