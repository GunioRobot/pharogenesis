addMenuItemsTo: aMenu hand: aHandMorph

	aMenu add: 'show cipher help' target: self action: #showHelpWindow.
	aMenu add: 'show cipher hints' target: self action: #showHintsWindow.
	aMenu add: 'clear cipher typing' target: self action: #clearTyping.
	aMenu add: 'enter a new cipher' target: self action: #enterANewCipher.
