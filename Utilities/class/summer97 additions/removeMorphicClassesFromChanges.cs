removeMorphicClassesFromChanges
	| morphicCats |
	morphicCats _ self classCategoriesStartingWith: 'Morphic'.
	morphicCats do:
		[:cat |
		(SystemOrganization superclassOrder: cat)
			do: [:class | class removeFromChanges]].

