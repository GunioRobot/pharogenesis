currentCategory
	"return a notion of the current category, or nil if there is no reasonable choice.  This method doesn't make a lot of sense in GeneralCeleste, but it is here for transition to a filtery future"
	

	"first, see if they have specifically selected a category filter"
	(self selectedActiveFilter notNil and: [ self selectedActiveFilter suggestedCategory notNil ])
		ifTrue: [ ^self selectedActiveFilter suggestedCategory ].

	"second, see if *any* current filter has a suggested category"
	self activeFilters do: [ :f | f suggestedCategory ifNotNil: [ ^f suggestedCategory ] ].

	"oh well, no reasonable choice"
	^nil
