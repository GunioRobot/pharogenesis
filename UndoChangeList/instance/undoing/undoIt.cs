undoIt
	"Undo by undoing all the changes in the change list"

	changeList do: [:undoable | undoable undoIt ].
