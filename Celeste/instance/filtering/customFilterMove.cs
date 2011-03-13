customFilterMove
	"Select or define and activate a custom filter."
	| filterList filterName msgList |
	filterList _ CustomFilters keys select: [:e | self categoryList includes: e].

	filterName _ currentMsgID ifNil: [self selectFilterFrom: filterList] ifNotNil: [self chooseFilterFor: currentMsgID from: filterList].
	((filterName isNil or: [filterName isEmpty]) or: [filterName = 'none']) ifTrue: [^ self].
	customFilterBlock _ self customFilterNamed: filterName.
	msgList _ self filteredMessagesIn: currentCategory.
	mailDB removeAll: msgList fromCategory: currentCategory.
	mailDB fileAll: msgList inCategory: filterName.
	customFilterBlock _ nil.
	self updateTOC