initialize
	"initialize the state of the receiver"
	super initialize.
	hasUnacceptedEdits _ false.
	hasEditingConflicts _ false.
	askBeforeDiscardingEdits _ true.
