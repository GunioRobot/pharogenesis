prologue: currentTime
	"Extends the AbstractAnimation prologue by saving the start state of the animation."

	undoable ifTrue: [
						(myWonderland getUndoStack)
								push: (UndoAnimation new: (self makeUndoVersion)).
					].

	(direction = Forward) ifTrue: [
									startState _ getStartStateFunction value.
									lastStartState _ startState.
									endState _ getEndStateFunction value.
								]
						ifFalse: [
									startState _ getStartStateFunction value.
									endState _ lastStartState.
								].


	super prologue: currentTime.
