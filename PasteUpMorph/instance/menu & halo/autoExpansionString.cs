autoExpansionString
	^ (self hasProperty: #automaticPhraseExpansion)
		ifTrue:
			['stop auto-phrase-expansion']
		ifFalse:
			['start auto-phrase-expansion']
