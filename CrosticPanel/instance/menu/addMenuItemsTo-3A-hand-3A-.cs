addMenuItemsTo: aMenu hand: aHandMorph 
	aMenu
		add: 'show crostic help' translated
		target: self
		action: #showHelpWindow.
	aMenu
		add: 'show crostic hints' translated
		target: self
		action: #showHintsWindow.
	aMenu
		add: 'show crostic errors' translated
		target: self
		action: #showErrors.
	aMenu
		add: 'clear crostic typing' translated
		target: self
		action: #clearTyping.
	aMenu
		add: 'open crostic file...' translated
		target: self
		action: #openFile