addCustomMenuItems: aCustomMenu hand: aHandMorph
	"Add custom menu items to a menu"

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addUpdating: #autoFitString target: self action: #autoFitOnOff.
	aCustomMenu addLine.
	aCustomMenu add: 'fix layout' translated target: self action: #fixLayout