buildWorldMenu
	"Build the menu that is put up when the screen-desktop is clicked on"

	| menu |

	menu _ MenuMorph new defaultTarget: self.
	self colorForDebugging: menu.
	menu addStayUpItem.
	self fillIn: menu from: {
		{'previous project' . { #myWorld . #goBack } }.
		{'jump to project...' . { #myWorld . #jumpToProject } }.
		{'save project on file...' . { #myWorld  . #saveOnFile } }.
		{'load project from file...' . { self  . #loadProject } }.
		nil}.
	myWorld addUndoItemsTo: menu.

		self fillIn: menu from: {
		{'restore display (r)' . { Display . #restoreMorphicDisplay } }.
		nil}.
	Preferences simpleMenus ifFalse:
		[self fillIn: menu from: { 
			{'open...' . { self  . #openWindow } }.
			{'windows & flaps...' . { self  . #windowsDo } }.
			{'changes...' . { self  . #changesDo } }}].
	self fillIn: menu from: { 
		{'help...' . { self  . #helpDo } }.
		{'appearance...' . { self  . #appearanceDo } }}.

	Preferences simpleMenus ifFalse:
		[self fillIn: menu from: {
			{'do...' . { Utilities . #offerCommonRequests} } }].

	self fillIn: menu from: { 
		nil.
		{'new morph...' . { self  . #newMorph } }.
		{'authoring tools...' . { self  . #scriptingDo } }.
		{'playfield options...' . { self  . #playfieldDo } }.
		{'projects...' . { self  . #projectDo } }}.
	Preferences simpleMenus ifFalse:
		[self fillIn: menu from: { 
			{'print PS to file...' . { self  . #printWorldOnFile } }.
			{'debug...' . { self  . #debugDo } }}].
	self fillIn: menu from: { 
		nil.
		{'save' . { self  . #saveSession } }.
		{'save as...' . { Smalltalk . #saveAs } }.
		{'save and quit' . { self  . #saveAndQuit } }.
		{'quit' . { self  . #quitSession } }}.

	^ menu