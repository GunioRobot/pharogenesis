buildWorldMenu
	"Build the menu that is put up when the screen-desktop is clicked on"

	| menu |
	menu _ MenuMorph new defaultTarget: self.
	menu commandKeyHandler: self.
	self colorForDebugging: menu.
	menu addStayUpItem.
	self fillIn: menu from: {
		{'previous project' . { #myWorld . #goBack }. 'return to the most-recently-visited project'}.
		{'jump to project...' . { #myWorld . #jumpToProject }. 'put up a list of all projects, letting me choose one to go to' }.
		{'save project on file...' . { #myWorld  . #saveOnFile }. 'save this project on a file' }.
		{'load project from file...' . { self  . #loadProject }. 'load a project from a file' }.
		nil}.
	myWorld addUndoItemsTo: menu.

		self fillIn: menu from: {
		{'restore display (r)' . { World . #restoreMorphicDisplay }. 'repaint the screen -- useful for removing unwanted display artifacts, lingering cursors, etc.' }.
		nil}.
	Preferences simpleMenus ifFalse:
		[self fillIn: menu from: { 
			{'open...' . { self  . #openWindow } }.
			{'windows...' . { self  . #windowsDo } }.
			{'changes...' . { self  . #changesDo } }}].
	self fillIn: menu from: { 
		{'help...' . { self  . #helpDo }.  'puts up a menu of useful items for updating the system, determining what version you are running, and much else'}.
		{'appearance...' . { self  . #appearanceDo }. 'put up a menu offering many controls over appearance.' }}.

	Preferences simpleMenus ifFalse:
		[self fillIn: menu from: {
			{'do...' . { Utilities . #offerCommonRequests} . 'put up an editible list of convenient expressions, and evaluate the one selected.' }}].

	self fillIn: menu from: { 
		nil.
		{'objects (o)' . { #myWorld . #activateObjectsTool } . 'A tool for finding and obtaining many kinds of objects'}.
		{'new morph...' . { self  . #newMorph }. 'Offers a variety of ways to create new objects'}.
		nil.
		{'authoring tools...' . { self  . #scriptingDo } . 'A menu of choices useful for authoring'}.
		{'playfield options...' . { self  . #playfieldDo } . 'A menu of options pertaining to this object as viewed as a playfield' }.
		{'flaps...'. { self . #flapsDo } . 'A menu relating to use of flaps.  For best results, use "keep this menu up"' }.
		{'projects...' . { self  . #projectDo }. 'A menu of commands relating to use of projects' }}.
	Preferences simpleMenus ifFalse:
		[self fillIn: menu from: { 
			{'print PS to file...' . { self  . #printWorldOnFile } . 'write the world into a postscript file'}.
			{'debug...' . { self  . #debugDo } . 'a menu of debugging items' }}].
	self fillIn: menu from: { 
		nil.
		{'save' . { SmalltalkImage current  . #saveSession } . 'save the current version of the image on disk' }.
		{'save as...' . { SmalltalkImage current . #saveAs }. 'save the current version of the image on disk under a new name.'}.
		{'save as new version' . { SmalltalkImage current . #saveAsNewVersion }. 'give the current image a new version-stamped name and save it under that name on disk.' }.
		{'save and quit' . { self  . #saveAndQuit } . 'save the current image on disk, and quit out of Squeak.'}.
		{'quit' . { self  . #quitSession } . 'quit out of Squeak.' }}.

	^ menu