editFilterNamed: filterName
	"edit the custom filter with the given name, and return the name"
	| filter |
	filter :=  NamedFilters at: filterName ifAbsentPut: [ CelesteCodeFilter new ].
	filter edit.
	^filterName