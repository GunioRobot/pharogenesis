verifyContents
	
	| newList existingSelection anIndex newRawList |
	(model editSelection == #editComment) ifTrue: [^ self].
	model classListIndex = 0 ifTrue: [^ self].
	newRawList _ model perform: getRawListSelector.
	newRawList == priorRawList ifTrue: [^ self].  "The usual case; very fast"
	priorRawList _ newRawList.
	newList _ (Array with: ClassOrganizer allCategory), priorRawList.
	list = newList ifTrue: [^ self].
	self flash.  "could get annoying, but hell"
	existingSelection _ self selection.
	self updateList.
	(anIndex _ newList indexOf: existingSelection ifAbsent: [nil])
		ifNotNil:
			[model noteSelectionIndex: anIndex for: getListSelector.
			self selectionIndex: anIndex]
		ifNil:
			[self changeModelSelection: 0]