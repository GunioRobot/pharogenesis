allCategories
	^ (universe packages collect: [:package | package category])
			asSet
			asSortedCollection: [:cat1 :cat2 | cat1 asString < cat2 asString]