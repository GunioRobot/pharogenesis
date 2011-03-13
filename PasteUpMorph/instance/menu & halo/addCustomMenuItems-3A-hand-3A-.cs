addCustomMenuItems: menu hand: aHandMorph 
	"Add morph-specific menu itemns to the menu for the hand"
	super addCustomMenuItems: menu hand: aHandMorph.

	menu addLine.
	self isWorldMorph ifTrue: [
			menu addLine.
			menu addUpdating: #showWorldMainDockingBarString action: #toggleShowWorldMainDockingBar.
		]. 
