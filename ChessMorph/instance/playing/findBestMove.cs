findBestMove
	| move |
	board searchAgent isThinking ifTrue:[^self].
	Cursor wait showWhile:[move _ board searchAgent think].
	self inform: 'I suggest: ', move printString.
	^move