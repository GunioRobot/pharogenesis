analyzeActionsForBalloonHelp: actionList
	| helpText |
	actionList do:[:msg|
		helpText _ ActionHelpText at: msg selector ifAbsent:[nil].
		helpText ifNotNil:[self setBalloonText: helpText].
	].
