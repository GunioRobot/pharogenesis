deselectDuring: aZeroArgumentBlock
	"evaluate aZeroArgumentBlock with the receiver deselected.
	answer the receiver"
	| wasSelected |
	wasSelected := selectionShowing.
	self deselect.
	aZeroArgumentBlock value.
	wasSelected ifTrue:[self select]