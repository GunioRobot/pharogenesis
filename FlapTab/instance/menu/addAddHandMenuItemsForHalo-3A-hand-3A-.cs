addAddHandMenuItemsForHalo: aMenu hand: aHandMorph
	aMenu add: 'tab color...' target: self action: #changeColor.
	aMenu add: 'flap color...' target: self action: #changeFlapColor


