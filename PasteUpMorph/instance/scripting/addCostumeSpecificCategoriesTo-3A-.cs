addCostumeSpecificCategoriesTo: aCategoryList
	#('pen trails' 'card/stack' 'animation'  'playfield') do:
		[:cat | aCategoryList addIfNotPresent: cat]
