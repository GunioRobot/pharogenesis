customFilterOn
	"Select or define and activate a custom filter."

	| filterName filterExpr filterMenu |
	filterMenu := CustomMenu new.

	currentMsgID ifNotNil: [
		(self filtersFor: currentMsgID from: (CustomFilters keys asSortedArray)) do: [ :name |
			filterMenu add: name action: name ].
		filterMenu addLine.].

	filterMenu add: '(none)' action: #none.
	filterMenu add: '<define new filter...>' action: #define.
	filterMenu add: '<edit exising filter...>' action: #edit.
	filterMenu add: '<delete a filter...>' action: #delete.
	filterMenu addLine.

	(CustomFilters keys asSortedArray) do: [ :name |
		filterMenu add: name action: name ].

	filterName _ filterMenu startUpWithCaption: 'Select a filter:'.

	filterName ifNil: [ ^self ].
	filterName = #none ifTrue: [^self customFilterOff ].
	filterName = #delete ifTrue: [ ^self deleteFilter].
	filterName = #edit
		ifTrue: [filterExpr _ self editFilter]
		ifFalse: [
			filterName = #define
				ifTrue: [filterExpr _ self defineFilter]
				ifFalse: [filterExpr _ CustomFilters at: filterName]].
	filterExpr isEmpty ifTrue: [^self].

	customFilterBlock _ Compiler evaluate: '[ :m | ', filterExpr, ']'.

	self updateTOC.
	self changed: #isCustomFilterOn.