itemsWithCategoriesDo: aBlock
	categories keysAndValuesDo: [:categoryName :items |
		items do: [:x |
			aBlock value: x value: categoryName.
		].
	].