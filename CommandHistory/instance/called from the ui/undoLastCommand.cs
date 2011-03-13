undoLastCommand
	"Undo the last command, i.e. move backward in the recent-commands tape, if possible."

	| aPhase anIndex |
	lastCommand ifNil: [^ self beep].

	(aPhase _ lastCommand phase) == #done
		ifFalse:
			[aPhase == #undone
				ifTrue:
					[anIndex _ history indexOf: lastCommand.
					anIndex > 1 ifTrue:
						[lastCommand _ history at: anIndex - 1]]].

	lastCommand undoCommand.
	lastCommand phase: #undone

	"Command undoLastCommand"
