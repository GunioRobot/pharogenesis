verifyContents
	| newItems existingSelection anIndex |
	"Called on window reactivation to react to possible structural changes.  Update contents if necessary."

	newItems _ self getList.
	((items == newItems) "fastest" or: [items = newItems]) ifTrue: [^ self].
	self flash.  "list has changed beneath us; could get annoying, but hell"
	existingSelection _ list stringAtLineNumber: (selection + 1).  "account for cursed ------ row"
	self list: newItems.
	(newItems size > 0 and: [newItems first isKindOf: Symbol]) ifTrue:
		[existingSelection _ existingSelection asSymbol].
	(anIndex _ newItems indexOf: existingSelection ifAbsent: [nil])
		ifNotNil:
			[model noteSelectionIndex: anIndex for: getListSelector.
			self update: getSelectionSelector.
			self topView displayEmphasized]
		ifNil:
			[self changeModelSelection: 0]
