addCustomMenuItems: aCustomMenu hand: aHandMorph
	"Add morph-specific items to the given menu which was invoked by the given hand."
	aCustomMenu add: 'add drop-shadow' action: #addDropShadow.