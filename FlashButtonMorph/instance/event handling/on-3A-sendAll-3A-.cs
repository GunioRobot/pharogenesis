on: eventName sendAll: actions
	"Note: We handle more than the standard Morphic events here"
	| actionList |
	events ifNil:[events _ Dictionary new].
	self analyzeActionsForBalloonHelp: actions.
	actionList _ events at: eventName ifAbsent:[#()].
	actionList _ actionList, actions.
	events at: eventName put: actionList.