addMenuItemsTo: aMenu hand: aHandMorph

	aMenu add: 'new game' target: self action: #newGame.
	aMenu add: 'reset...' target: self action: #reset.
	animateMoves
		ifTrue: [aMenu add: 'don''t animate moves' target: self action: #dontAnimateMoves]
		ifFalse: [aMenu add: 'animate moves' target: self action: #animateMoves]

