destroyCurrentFilter
	"remove the current filter, and take it out of NamedFilters"
	| filter |
	self selectedActiveFilter ifNil: [ ^self ].
	(self confirm: 'Are you sure you want to delete this filter forever?')
		ifFalse: [ ^self ].

	filter := self selectedActiveFilter.
	(self isNamedFilter: filter) ifTrue: [ "can't be too certain!"
		NamedFilters removeKey: (self nameOfFilter: filter) ].
	self removeSelectedFilter.
