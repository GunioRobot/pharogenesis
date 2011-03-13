undoTo
	"Incomplete.  Allow the user to choose a point somewhere in the undo/redo tape, and undo his way to there.   Applicable only if infiniteUndo is set.  Not yet functional."

	| anIndex commandList aMenu reply |
	(anIndex _ self historyIndexOfLastCommand) ifNil: [^ self beep].
	commandList _ history
		copyFrom:	((anIndex - 10) max: 1)
		to:			((anIndex + 10) min: history size).
	aMenu _ SelectionMenu labels:  (commandList collect: [:cmd | cmd cmdWording]) selections: commandList.
	reply _ aMenu startUpWithCaption: 'undo or redo to...'.
	reply ifNotNil: [self halt: 'now for the rest...!']

	"Command undoTo"
