setSelection: newSpec
	"A selectionSpec is {Inner morph.  Where clicked.  Outer morph}.
	First mouseDown starts a selection (with outerMorph == nil).
	Dragging more than 4 pixels means to grab a copy of the current outer selection.
		The current selection is the outerMorph, or the inner if it is nil.
	Each mouseUp extends the selection to the next outer morph that is selectable.
		Except if this is the first click."
	| rootTile |
	(rootTile _ self rootTile) valueOfProperty: #selectionSpec ifPresentDo:
		[:oldSpec | oldSpec third ifNotNilDo: [:m | m deselect]].
	(newSpec == nil or: [newSpec third == nil and: [self isMethodNode]])
		ifTrue: [self deselect.
			^ rootTile removeProperty: #selectionSpec].

	"Select outer morph of the new selection"
	newSpec third == nil
		ifTrue: [self select  "first click down"]
		ifFalse: [newSpec third select  "subsequent clicks"].
	rootTile setProperty: #selectionSpec toValue: newSpec