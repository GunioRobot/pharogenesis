testSortBy
	" can only be used if the collection tested can include sortable elements :"
	| result tmp |
	self 
		shouldnt: [ self collectionWithSortableElements ]
		raise: Error.
	self shouldnt: [self collectionWithSortableElements anyOne < self collectionWithSortableElements anyOne] raise: Error.
	result := self collectionWithSortableElements sortBy: [ :a :b | a < b ].

	"verify content of 'result' : "
	result do: 
		[ :each | 
		(self collectionWithSortableElements occurrencesOf: each) = (result occurrencesOf: each) ].
	tmp := result first.
	result do: 
		[ :each | 
		self assert: each >= tmp.
		tmp := each ].

	"verify size of 'result' :"
	self assert: result size = self collectionWithSortableElements size