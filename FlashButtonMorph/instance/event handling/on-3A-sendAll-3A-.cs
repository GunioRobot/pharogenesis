on: eventName sendAll: actions
	"Note: We handle more than the standard Morphic events here"
	| actionList |
	events ifNil:[events := Dictionary new].
	self analyzeActionsForBalloonHelp: actions.
	actionList := events at: eventName ifAbsent:[#()].
	actionList := actionList, actions.
	events at: eventName put: actionList.