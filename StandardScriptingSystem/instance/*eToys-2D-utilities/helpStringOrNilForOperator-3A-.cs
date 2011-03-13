helpStringOrNilForOperator: anOperator
	"Answer the help string associated with the given operator, nil if none found."

	| anIndex opsAndHelp |
	(anIndex := (opsAndHelp := self arithmeticalOperatorsAndHelpStrings) first indexOf: anOperator) > 0
		ifTrue:	[^ (opsAndHelp second at: anIndex) translated].

	(anIndex := (opsAndHelp := self numericComparitorsAndHelpStrings) first indexOf: anOperator) > 0
		ifTrue:	[^ (opsAndHelp second at: anIndex) translated].

	anOperator = #, ifTrue:
		[^ 'Concatenate two Strings' translated].

	^ nil