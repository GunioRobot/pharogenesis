addMenuItemsTo: aMenu hand: aHandMorph 
	aMenu
		add: 'show cipher help' translated
		target: self
		action: #showHelpWindow.
	aMenu
		add: 'show cipher hints' translated
		target: self
		action: #showHintsWindow.
	aMenu
		add: 'clear cipher typing' translated
		target: self
		action: #clearTyping.
	aMenu
		add: 'enter a new cipher' translated
		target: self
		action: #enterANewCipher.
	aMenu
		add: 'quote from Squeak' translated
		target: self
		action: #squeakCipher