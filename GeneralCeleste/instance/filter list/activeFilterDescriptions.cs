activeFilterDescriptions
	"an indexable collection with a 1-line summary of each active filter"

	^self activeFilters collect: 
			[:filter | 
			(self isNamedFilter: filter) 
				ifTrue: ['(' , (self nameOfFilter: filter) , ') ' , filter printString]
				ifFalse: [filter printString]]