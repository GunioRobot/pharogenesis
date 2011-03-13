cantUndo
	"Called by client to indicate that the prior undoable command is no longer undoable"

	lastCommand _ nil.
	history _ OrderedCollection new.