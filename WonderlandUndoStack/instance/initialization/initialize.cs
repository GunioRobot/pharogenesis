initialize
	"Initializes the undo stack."

	theStack _ OrderedCollection new.
	stackIsOpen _ true.
	maxStackDepth _ (WonderlandConstants at: 'maxUndoDepth').
