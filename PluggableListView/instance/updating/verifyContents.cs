verifyContents
	| newItems existingSelection anIndex |
	"Called on window reactivation to react to possible structural changes.  Update contents if necessary."

	newItems := self getList.
	((items == newItems) "fastest" or: [items = newItems]) ifTrue: [^ self].
	self flash.  "list has changed beneath us; could get annoying, but hell"
	existingSelection := list stringAtLineNumber: (selection + (topDelimiter ifNil: [0] ifNotNil: [1])).  "account for cursed ------ row"
	self list: newItems.

	(newItems size > 0 and: [newItems first isKindOf: Symbol]) ifTrue:
		[existingSelection := existingSelection asSymbol].
	(anIndex := newItems indexOf: existingSelection ifAbsent: [nil])
		ifNotNil:
			[model noteSelectionIndex: anIndex for: getListSelector.]
		ifNil:
			[self changeModelSelection: 0].
	selection := 0. " to display the list without selection "
	self displayView.
	self update: getSelectionSelector.
