customFilterOn
	"Select or define and activate a custom filter."

	| filterList filterName filterExpr |
	filterList _ CustomFilters keys asSortedCollection asOrderedCollection.
	filterList addFirst: '(none)'.
	filterList addLast: '<define new filter...>'.
	filterList addLast: '<edit exising filter...>'.
	filterList addLast: '<delete a filter...>'.
	filterName _ (CustomMenu selections: filterList)
			startUpWithCaption: 'Select a filter:'.
	filterName ifNil: [ ^self ].
	filterName = '(none)' ifTrue: [^self customFilterOff ].
	filterName = '<delete a filter...>' ifTrue: [ ^self deleteFilter].
	filterName = '<edit exising filter...>'
		ifTrue: [filterExpr _ self editFilter]
		ifFalse: [
			filterName = '<define new filter...>'
				ifTrue: [filterExpr _ self defineFilter]
				ifFalse: [filterExpr _ CustomFilters at: filterName]].
	filterExpr isEmpty ifTrue: [^self].
	customFilterBlock _ Compiler evaluate: '[ :m | ', filterExpr, ']'.
	self updateTOC.
	self changed: #isCustomFilterOn.