redoNextCommand
	"If there is a way to 'redo' (move FORWARD) in the undo/redo history tape, do it."

	| anIndex |
	lastCommand ifNil: [^ Beeper beep].
	lastCommand phase == #undone
		ifFalse:
			[anIndex _ history indexOf: lastCommand.
			(anIndex < history size)
				ifTrue:
					[lastCommand _ history at: anIndex + 1]
				ifFalse:
					[^ Beeper beep]].

	lastCommand redoCommand.
	lastCommand phase: #done
