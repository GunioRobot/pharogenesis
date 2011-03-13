hideList
	"Hide the list."

	self listMorph ifNil: [^self].
	self listVisible ifFalse: [^self].
	self listMorph delete.
	self listMorph selectionIndex = self listSelectionIndex
		ifFalse: [self listMorph changeModelSelection: self listMorph selectionIndex].
	self roundedCorners: #(1 2 3 4).
	(self buttonMorph ifNil: [^self]) roundedCorners: (self roundedCorners copyWithoutAll: #(1 2)).
	self changed.
	self wantsKeyboardFocus
		ifTrue: [self takeKeyboardFocus]