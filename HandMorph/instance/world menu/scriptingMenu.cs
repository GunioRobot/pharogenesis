scriptingMenu
	"Build the scripting menu for the world."
	| menu |
	menu _ (MenuMorph entitled: 'authoring tools...') defaultTarget: self.
	menu addStayUpItem.
	menu add: 'standard parts bin' target: self presenter action: #createStandardPartsBin.
	menu balloonTextForLastItem: 'A bin of standard parts, from which you can drag out useful morphs.'.
	menu add: 'custom parts bin' target: self presenter action: #launchCustomPartsBin.
	menu balloonTextForLastItem: 'A customized bin of parts.  To define what the custom parts bin is, edit any existing parts bin and tell it to be saved as the custom parts bin.'.
	menu add: 'view trash contents' target: self action: #openScrapsBook.
	menu balloonTextForLastItem: 'The place where all your trashed morphs go.'.
	menu add: 'empty trash can' target: Utilities action: #emptyScrapsBook.
	menu balloonTextForLastItem: 'Empty out all the morphs that have accumulated in the trash can.'.
	menu add: 'new scripting area' target: self action: #detachableScriptingSpace.
	menu balloonTextForLastItem: 'A window set up for simple scripting.'.
	menu addLine.
	menu add: 'unlock locked objects' action: #unlockWorldContents.
	menu balloonTextForLastItem: 'If any items on the world desktop are currently locked, unlock them.'.
	menu add: 'unhide hidden objects' action: #showHiders.
	menu balloonTextForLastItem: 'If any items on the world desktop are currently hidden, make them visible.'.
	^ menu