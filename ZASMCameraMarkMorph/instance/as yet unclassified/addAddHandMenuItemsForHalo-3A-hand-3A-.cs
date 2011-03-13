addAddHandMenuItemsForHalo: aMenu hand: aHandMorph
	"Add halo menu items to be handled by the invoking hand. The halo menu is invoked by clicking on the menu-handle of the receiver's halo."

	aMenu add: 'Go to this mark' action: #gotoMark.
	aMenu add: 'Set transition' action: #setTransition:.
	aMenu addLine.
	^super addAddHandMenuItemsForHalo: aMenu hand: aHandMorph
