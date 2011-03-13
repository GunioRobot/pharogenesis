helpStringOrNilForOperator: anOperator
	"Answer the help string associated with the given operator, nil if none found."

	| anIndex opsAndHelp |
	(anIndex _ (opsAndHelp _ self arithmeticalOperatorsAndHelpStrings) first indexOf: anOperator) > 0
		ifTrue:	[^ (opsAndHelp second at: anIndex) translated].

	(anIndex _ (opsAndHelp _ self numericComparitorsAndHelpStrings) first indexOf: anOperator) > 0
		ifTrue:	[^ (opsAndHelp second at: anIndex) translated].

	anOperator = #, ifTrue:
		[^ 'Concatenate two Strings' translated].

	^ nil