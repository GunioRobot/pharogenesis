renameScript: oldSelector
	| reply newSelector aUserScript |
	self flag: #deferred.
	aUserScript _ self class userScriptForPlayer: self selector: oldSelector.
	aUserScript isTextuallyCoded ifTrue:
		[self inform: 'Sorry, for now you can only rename tiled scripts'.
		^ self].

	reply _   FillInTheBlank request: 'Script Name' initialAnswer: oldSelector.
 	reply size == 0 ifTrue: [^ self].
	reply first isUppercase ifTrue: [^ self inform: 'Illegal script name'].
	(Scanner isLiteralSymbol: reply) ifFalse: [^ self inform: 'Bad script name, please try again'].
	((newSelector _ reply asSymbol) == oldSelector) ifTrue: [^ self].
	(ScriptingSystem isAcceptablePlayerScriptName: newSelector)
		ifFalse: [^ self inform: 'Sorry, "', newSelector, '" is reserved.'].
	self renameScript: oldSelector newSelector: newSelector
