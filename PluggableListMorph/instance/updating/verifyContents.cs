verifyContents
	| newList existingSelection anIndex |
	"Called periodically, or at least on window reactivation to react to possible structural changes.  Update contents if necessary."
	newList _ self getList.
	((list == newList) "fastest" or: [list = newList]) ifTrue: [^ self].
	self flash.  "list has changed beneath us; could get annoying, but hell"
	existingSelection _ selection.
	self list: newList.
	(anIndex _ newList indexOf: existingSelection ifAbsent: [nil])
		ifNotNil:
			[model noteSelectionIndex: anIndex for: getListSelector.
			self selectionIndex: anIndex]
		ifNil:
			[self changeModelSelection: 0]
