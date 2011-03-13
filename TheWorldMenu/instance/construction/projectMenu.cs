projectMenu
	"Build the project menu for the world."
	| menu |

	self flag: #bob0302.

	menu _ self menu: 'projects...'.
	self fillIn: menu from: { 
		{ 'save on server (also makes a local copy)' . { #myProject . #storeOnServer } }.
		{ 'save to a different server' . { #myProject . #saveAs } }.
		{ 'save project on local file only' . { #myWorld . #saveOnFile } }.
		{ 'see if server version is more recent...' . { #myProject . #loadFromServer } }.
		{ 'load project from file...' . { self . #loadProject } }.
		nil.
		{ #universalTilesString . { self . #toggleTileEra }. 'yes: new tiles in scripts and viewers.
no: old tiles'}.
		{ #largeTilesString . { self . #toggleLargeTiles }. 
	'yes: tiles in scripts and viewers are tall and green. no: tiles are short and transparent'}.
		nil.
	}.

	self fillIn: menu from:
		{{'show project hierarchy'. {Project. #showProjectHierarchyInWindow}. 'Opens a window that shows names and relationships of all the projects in your system.'}.
		nil}.

	self mvcProjectsAllowed ifTrue: [
		self fillIn: menu from: {
			{ 'create new mvc project'. { self . #openMVCProject } }.
		}
	].
	self fillIn: menu from: { 
		{ 'create new morphic project' . { self . #openMorphicProject } }.
		nil.
		{ 'go to previous project' . { Project . #returnToPreviousProject } }.
		{ 'go to next project' . { Project . #advanceToNextProject } }.
		{ 'jump to project...' . { #myWorld . #jumpToProject } }.
	}.
	Preferences simpleMenus ifFalse: [
		self fillIn: menu from: { 
			nil.
			{ 'save for future revert' . { #myProject . #saveForRevert } }.
			{ 'revert to saved copy' . { #myProject . #revert } }.
		}.
	].

	^ menu