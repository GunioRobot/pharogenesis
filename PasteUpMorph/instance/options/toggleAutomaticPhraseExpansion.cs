toggleAutomaticPhraseExpansion
	| expand |
	expand _ self hasProperty: #automaticPhraseExpansion.
	expand
		ifTrue:
			[self removeProperty: #automaticPhraseExpansion]
		ifFalse:
			[self setProperty: #automaticPhraseExpansion toValue: true]