invertSelections
	"Invert the selectedness of each item in the changelist"

	listSelections _ listSelections collect: [ :ea | ea not].
	listIndex _ 0.
	self changed: #allSelections.
	self contentsChanged