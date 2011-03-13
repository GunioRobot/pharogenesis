addDebuggingItemsTo: aMenu hand: aHandMorph
	aMenu add: 'debug...' subMenu:  (self buildDebugMenu: aHandMorph)