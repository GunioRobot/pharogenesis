addModelItemsToWindowMenu: aMenu
	"Add model-related item to the window menu"

	super addModelItemsToWindowMenu: aMenu. 
	aMenu addLine.
	aMenu add: 'what to show...' translated target: self action: #offerWhatToShowMenu