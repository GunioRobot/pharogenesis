chooseFontWithPrompt: aPrompt andSendTo: aReceiver withSelector: aSelector
	Smalltalk isMorphic
		ifFalse:
			[Utilities mvcPromptForFont: aPrompt andSendTo: aReceiver withSelector: aSelector]
		ifTrue:
			[Utilities promptForFont: aPrompt andSendTo: aReceiver withSelector: aSelector]