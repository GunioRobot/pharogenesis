removeAllSuchThat: aBlock
	| newItems |
	categories keysAndValuesDo: [:categoryName :oldItems |
		newItems _ oldItems copy.
		oldItems do: [:x | (aBlock value: x) ifTrue: [newItems remove: x]].
		categories at: categoryName put: newItems.
	].