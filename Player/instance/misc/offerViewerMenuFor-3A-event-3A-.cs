offerViewerMenuFor: aViewer event: evt
	"Put up the Viewer menu on behalf of the receiver."

	| aMenu aWorld  |
	aWorld _ aViewer world.
	aMenu _ MenuMorph new defaultTarget: self.
	costumes ifNotNil:
		[(costumes size > 1 or: [costumes size == 1 and: [costumes first ~~ costume renderedMorph]])
			ifTrue:
				[aMenu add: 'forget other costumes' target: self selector: #forgetOtherCostumes]].
	aMenu addLine.
	aMenu add: 'add a new instance variable' target: self action: #addInstanceVariable.
	aMenu add: 'add a new script' target: aViewer action: #newPermanentScript.
	aMenu add: 'expunge empty scripts' target: self action: #expungeEmptyScripts.
	aMenu addLine.
	aMenu add: 'tile representing me' action: #tearOffTileForSelf.
	aMenu add: 'reveal me' target: self selector: #revealPlayerIn: argument: aWorld.
	aMenu add: 'grab me' target: self selector: #grabPlayerIn: argument: aWorld.
	aMenu addLine.
	aMenu add: 'inspect morph' target: costume selector: #inspect.
	aMenu add: 'inspect player' target: self selector: #inspect.
	self belongsToUniClass ifTrue:
		[aMenu add: 'browse class' target: self action: #browsePlayerClass.
		aMenu add: 'inspect class' target: self class action: #inspect].

	aMenu popUpEvent: evt in: aWorld
