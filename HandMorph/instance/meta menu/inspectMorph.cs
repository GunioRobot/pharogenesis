inspectMorph
	| targetMorph |
	targetMorph _ self chooseTargetSubmorphOf: argument caption: 'inspect whom?
(deepest at top)'.
	targetMorph ifNotNil: [targetMorph inspect]
	
