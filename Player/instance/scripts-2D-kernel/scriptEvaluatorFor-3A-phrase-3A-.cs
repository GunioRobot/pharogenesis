scriptEvaluatorFor: aSelector phrase: aPhrase
	| anEvaluator |
	anEvaluator _ ScriptEvaluatorMorph new playerScripted: self.
	anEvaluator initializeFor: aPhrase.
	^ anEvaluator bringUpToDate