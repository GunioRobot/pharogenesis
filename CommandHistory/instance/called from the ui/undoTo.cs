undoTo
	"Not yet functional, and not yet sent.  Allow the user to choose a point somewhere in the undo/redo tape, and undo his way to there.   Applicable only if infiniteUndo is set. "

	| anIndex commandList aMenu reply |
	(anIndex _ self historyIndexOfLastCommand) == 0 ifTrue: [^ Beeper beep].
	commandList _ history
		copyFrom:	((anIndex - 10) max: 1)
		to:			((anIndex + 10) min: history size).
	aMenu _ SelectionMenu labels:  (commandList collect: [:cmd | cmd cmdWording truncateWithElipsisTo: 20]) selections: commandList.
	reply _ aMenu startUpWithCaption: 'undo or redo to...'.
	reply ifNotNil: [self inform: #deferred]

	"ActiveWorld commandHistory undoTo"
