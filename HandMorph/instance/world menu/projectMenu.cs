projectMenu
	"Build the project menu for the world."
	| menu |
	menu _ (MenuMorph entitled: 'projects...') defaultTarget: self.
	menu addStayUpItem.
	menu add: 'save project on file...' target: self world 
		action: #saveOnFile.
	menu add: 'load project from file...' target: self 
		action: #loadProject.
	menu addLine.
	(Preferences mvcProjectsAllowed and: [Smalltalk includesKey: #StandardSystemView])
		ifTrue: [menu add: 'create new mvc project' action: #openMVCProject].
	menu add: 'create new morphic project' action: #openMorphicProject.

	menu addLine.
	menu add: 'go to previous project' target: Project action: #advanceToPreviousProject.
	menu add: 'go to next project' target: Project action: #returnToPreviousProject.
	menu add: 'jump to project...' target: owner action: #jumpToProject.

	menu addLine.
	menu add: 'save on server (also makes a local copy)' target: self world project 
		action: #storeOnServer.
	menu add: 'saveAs' target: self world project 
		action: #saveAs.
	menu add: 'see if server version is more recent...' target: self world project 
		action: #loadFromServer.

	Preferences simpleMenus ifFalse:
		[menu addLine.
		menu add: 'save for future revert' target: self world project 
			action: #saveForRevert.
		menu add: 'revert to saved copy' target: self world project action: #revert].

	^ menu