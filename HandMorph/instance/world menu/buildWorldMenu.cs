buildWorldMenu
	"Build the meta menu for the world."
	| menu |
	menu _ MenuMorph new defaultTarget: self.
	menu addStayUpItem.
	menu add: 'previous project' target: owner action: #goBack.
	menu add: 'jump to project...' target: owner action: #jumpToProject.
	menu add: 'save project on file...' target: self world  action: #saveOnFile.
	menu add: 'load project from file...' target: self  action: #loadProject.
	menu addLine.

	menu add: 'restore display' target: self world action: #restoreDisplay.

	menu addLine.

	Preferences simpleMenus ifFalse:
		[menu add: 'open...' action: #openWindow.
		menu add: 'windows & flaps...' action: #windowsDo.
		menu add: 'changes...' action: #changesDo].
	menu add: 'help...' action: #helpDo.
	menu add: 'appearance...' action: #appearanceDo.
	Preferences simpleMenus ifFalse:
		[menu add: 'do...' target: Utilities action: #offerCommonRequests].

	menu addLine.
	menu add: 'new morph...' action: #newMorph.
	menu add: 'authoring tools...' action: #scriptingDo.
	menu add: 'playfield options...' action: #playfieldDo.
	menu add: 'projects...' action: #projectDo.

	Preferences simpleMenus ifFalse:
		[menu add: 'print PS to file...' action: #printWorldOnFile.
		menu add: 'debug...' action: #debugDo].

	menu addLine.
	menu add: 'save' action: #saveSession.
	menu add: 'save as...' action: #saveAs.
	menu add: 'save and quit' action: #saveAndQuit.
	menu add: 'quit' action: #quitSession.

	^ menu