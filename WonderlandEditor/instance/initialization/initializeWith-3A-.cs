initializeWith: aWonderland
	"Initialize the editor with the Wonderland."

	myWonderland _ aWonderland.

	myTabs _ (WonderlandEditorTabs newFor: aWonderland).
	self addMorph: myTabs.

	myActorBrowser _ (WonderlandActorBrowser newFor: myWonderland).
	myActorBrowser setActorViewer: (myTabs getActorViewer).
	self addMorph: (myActorBrowser getMorph).

	myControls _ WonderlandControls newFor: aWonderland.
	self addMorph: myControls.

	self position: 200@20.
	self extent: 650@375.
	self color: (Color r: 0.784 g: 0.784 b: 0.784).
	self openInWorld.
