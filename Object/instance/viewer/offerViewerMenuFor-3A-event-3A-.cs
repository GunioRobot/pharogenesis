offerViewerMenuFor: aViewer event: evt
	"Offer the primary Viewer menu to the user.  Copied up from Player code, but most of the functions suggested here don't work for non-Player objects, many aren't even defined, some relate to exploratory sw work not yet reflected in the current corpus.  Think of this as a beginning!"

	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addStayUpItem.
	aMenu title: '**CAUTION -- UNDER CONSTRUCTION!**
', self nameForViewer.
	(aViewer affordsUniclass and: [self belongsToUniClass not]) ifTrue:
		[aMenu add: 'give me a Uniclass' action: #assureUniClass.
		aMenu addLine].

	aMenu add: 'rename me' target: aViewer selector: #chooseNewNameForReference.
	self belongsToUniClass ifTrue:
		[aMenu add: 'add a new instance variable' target: self selector: #addInstanceVariableIn: argument: aViewer.
		aMenu add: 'add a new script' target: aViewer selector: #newPermanentScriptIn: argument: aViewer.
		aMenu addLine.
		aMenu add: 'make my class be first-class' target: self selector: #makeFirstClassClassIn: argument: aViewer.
		aMenu add: 'move my changes up to my superclass' target: self action: #promoteChangesToSuperclass.
		aMenu addLine].

	aMenu add: 'toggle scratch pane' target: aViewer selector: #toggleScratchPane.
	aMenu add: 'make a nascent script for me' target: aViewer selector: #makeNascentScript.
	aMenu add: 'tear off a tile' target: self selector: #launchTileToRefer.
	aMenu addLine.
	aMenu add: 'inspect me' target: self selector: #inspect.
	aMenu add: 'inspect my class' target: self class action: #inspect.
	aMenu add: 'references to me' target: aViewer action: #browseReferencesToObject.
	aMenu addLine.
	aMenu add: 'browse full' action: #browseOwnClassFull.
	aMenu add: 'browse hierarchy' action: #browseOwnClassHierarchy.
	aMenu add: 'browse protocol' action: #browseOwnClassProtocol.
	aMenu add: 'browse sub-protocol' action: #browseOwnClassSubProtocol.
	aMenu addLine.
	aMenu add: 'set user level...' target: aViewer action: #setUserLevel.
	aMenu addLine.
	aMenu add: 'inspect this Viewer' target: aViewer action: #inspect.

	aMenu popUpEvent: evt in: aViewer currentWorld