addCustomMenuItems: aMenu hand: aHandMorph
	"Add custom menu items"

	super addCustomMenuItems: aMenu hand: aHandMorph.
	aMenu add: 'add pin' translated target: self selector: #addPin.
