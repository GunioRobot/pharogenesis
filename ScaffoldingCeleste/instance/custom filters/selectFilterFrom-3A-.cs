selectFilterFrom: filters
	"choose a filter from the specified names.  May also define a new filter and return it, or delete a filter.  Returns either the name of a filter, or nil"
	| filterName filterList |
	filterList _ filters asSortedCollection asOrderedCollection.
	filterList addFirst: '(none)'.
	filterList addLast: '<define new filter...>'.
	filterList addLast: '<edit exising filter...>'.
	filterList addLast: '<delete a filter...>'.

	filterName _ (CustomMenu selections: filterList)
			startUpWithCaption: 'Select a filter:'.

	(filterName isNil or: [filterName isEmpty]) ifTrue: [ ^nil ].

	filterName = '(none)' ifTrue: [^nil ].

	filterName = '<delete a filter...>' ifTrue: [ ^self deleteFilter].

	filterName = '<edit exising filter...>'
		ifTrue: [filterName _ self editFilter]
		ifFalse: [
			filterName = '<define new filter...>'
				ifTrue: [filterName _ self defineFilter]].

	^filterName