addModelItemsToWindowMenu: aMenu
	aMenu addLine.
	self listMenu: aMenu shifted: false.
	aMenu addLine.
	aMenu add: 'log to Transcript' target: self selector: #showResult.
	^aMenu.
