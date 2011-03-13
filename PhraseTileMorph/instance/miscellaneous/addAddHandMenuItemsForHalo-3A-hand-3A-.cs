addAddHandMenuItemsForHalo: aMenu hand: aHand
	"Add additional items to the halo manu"

	super addAddHandMenuItemsForHalo: aMenu hand: aHand.
	aMenu add: 'Sprout a new scriptor around this phrase' target: self action: #sproutNewScriptor