customFilterMove
	"Select or define and activate a custom filter."
	| filterList filterName filterExpr msgList |
	filterList _ CustomFilters keys asSortedCollection asOrderedCollection select: [:e | self categoryList includes: e].
	filterName _ (CustomMenu selections: filterList)
				startUpWithCaption: 'Select a move filter:'.
	filterName ifNil: [^ self].
	filterExpr _ CustomFilters at: filterName.
	filterExpr isEmpty ifTrue: [^ self].
	customFilterBlock _ Compiler evaluate: '[ :m | ' , filterExpr , ']'.
	msgList _ self filteredMessagesIn: currentCategory.
	mailDB removeAll: msgList fromCategory: currentCategory.
	mailDB fileAll: msgList inCategory: filterName.
	customFilterBlock _ nil.
	self updateTOC