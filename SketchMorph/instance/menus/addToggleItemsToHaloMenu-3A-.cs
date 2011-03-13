addToggleItemsToHaloMenu: aCustomMenu 
	"Add toggle-items to the halo menu"
	super addToggleItemsToHaloMenu: aCustomMenu.
	aCustomMenu addUpdating: #useInterpolationString target: self action: #toggleInterpolation