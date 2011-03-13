selectionUnmodifiable
	"Answer if the current selected variable is modifiable via acceptance in the code pane.  For most inspectors, no selection and a selection of self (selectionIndex = 1) are unmodifiable"

	^ selectionIndex <= 2