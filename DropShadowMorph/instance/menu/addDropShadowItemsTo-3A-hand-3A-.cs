addDropShadowItemsTo: aMenu hand: aHand

	aMenu addLine.
	aMenu add: 'set shadow color' target: self selector: #changeColor.
	aMenu add: 'set shadow offset' target: self selector: #setOffset:.
	aMenu add: 'remove shadow' target: self selector: #removeDropShadow.
