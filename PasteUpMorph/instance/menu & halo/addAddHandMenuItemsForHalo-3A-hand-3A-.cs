addAddHandMenuItemsForHalo: aMenu hand: aHandMorph
	"Add halo menu items to be handled by the invoking hand. The halo menu is invoked by clicking on the menu-handle of the receiver's halo.  Copied down from morph and hand-edited for the world"

	self isWorldMorph ifFalse: [^ super addAddHandMenuItemsForHalo: aMenu hand: aHandMorph].

	aMenu addLine.
	aMenu add: 'copy Postscript' action: #clipPostscript.
	aMenu add: 'print PS to file...' target: self selector: #printPSToFile.
	aMenu addLine.
	self addFillStyleMenuItems: aMenu hand: aHandMorph.
	aMenu
		defaultTarget: self;
		add: 'add mouse up action' action: #addMouseUpAction;
		add: 'remove mouse up action' action: #removeMouseUpAction;
		defaultTarget: aHandMorph.
