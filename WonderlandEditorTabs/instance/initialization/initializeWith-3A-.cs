initializeWith: aWonderland
	"Initialize the editor with the Wonderland."

	myWonderland _ aWonderland.

	myScriptEditor _ (WonderlandScriptEditor new).
	self addPanel: (myScriptEditor getMorph).
	(self tabsMorph submorphs at: 1) tabSelected.
	myScriptEditor setBindings: (myWonderland getNamespace).

	myActorViewer _ WonderlandActorViewer new.
	myActorViewer initializeWith: aWonderland.
	self addPanel: myActorViewer.

	myQuickReference _ (WonderlandQuickReference new).
	self addPanel: (myQuickReference getMorph).
