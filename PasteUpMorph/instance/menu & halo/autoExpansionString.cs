autoExpansionString
	"Answer the string to be shown in a menu to represent the auto-phrase-expansion status"

	^ (self hasProperty: #automaticPhraseExpansion)
		ifTrue:
			['<on>auto-phrase-expansion']
		ifFalse:
			['<off>auto-phrase-expansion']
