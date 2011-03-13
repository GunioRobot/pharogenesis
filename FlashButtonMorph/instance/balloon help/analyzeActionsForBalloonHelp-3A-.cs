analyzeActionsForBalloonHelp: actionList
	| helpText |
	actionList do:[:msg|
		helpText := ActionHelpText at: msg selector ifAbsent:[nil].
		helpText ifNotNil:[self setBalloonText: helpText].
	].
