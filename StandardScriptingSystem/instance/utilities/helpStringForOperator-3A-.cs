helpStringForOperator: anOperator
	"Answer the help string associated with the given operator"

	| anIndex opsAndHelp |
	(anIndex _ (opsAndHelp _ self arithmeticalOperatorsAndHelpStrings) first indexOf: anOperator) > 0
		ifTrue:	[^ opsAndHelp second at: anIndex].

	(anIndex _ (opsAndHelp _ self numericComparitorsAndHelpStrings) first indexOf: anOperator) > 0
		ifTrue:	[^ opsAndHelp second at: anIndex].

	^ 'And I called my cow, no help now' 
	"This should never be seen, but if it is, we should hear the moo eventually"