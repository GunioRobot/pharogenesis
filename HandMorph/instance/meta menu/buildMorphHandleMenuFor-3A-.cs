buildMorphHandleMenuFor: argMorph
	"Build the morph menu for the given morph's halo's menu handle. This menu has two sections. The first section contains commands that are interpreted by the hand; the second contains commands provided by the target morph. This method allows the morph to decide which items should be included in the hand's section of the menu."

	| menu |
	argMorph == owner "i.e., the world" ifTrue:
		[^ self buildWorldMenu].

	argument _ argMorph.
	menu _ MenuMorph new defaultTarget: self.
	menu addStayUpItem.
	argMorph addAddHandMenuItemsForHalo: menu hand: self.
	menu defaultTarget: argMorph.
	argMorph addCustomHaloMenuItems: menu hand: self.
	argMorph costumee ifNotNil: [argMorph costumee addPlayerMenuItemsTo: menu hand: self].
	menu defaultTarget: self.
	Preferences noviceMode ifFalse:
		[argMorph addDebuggingItemsTo: menu hand: self].

	^ menu
