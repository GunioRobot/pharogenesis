customFilterNames
	"return a list of available custom filters.  They are the names of named filters which are also code filters"
	^(NamedFilters keys select: [ :name |
		(NamedFilters at: name) isCodeFilter ]) asSortedArray