addMenuItemsTo: aMenu hand: aHandMorph

	aMenu add: 'show crostic help' target: self action: #showHelpWindow.
	aMenu add: 'show crostic hints' target: self action: #showHintsWindow.
	aMenu add: 'show crostic errors' target: self action: #showErrors.
	aMenu add: 'clear crostic typing' target: self action: #clearTyping.
	aMenu add: 'open crostic file...' target: self action: #openFile.
