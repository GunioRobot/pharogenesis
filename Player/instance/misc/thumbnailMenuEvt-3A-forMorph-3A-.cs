thumbnailMenuEvt: anEvent forMorph: aMorph
	"The mouse went down in the thumbnail of a Viewer for the receiver"

	| aMenu aWorld aViewer |
	aWorld _ aMorph world.
	aViewer _ aMorph ownerThatIsA: Viewer.
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu add: 'set new costume...' action: #newCostume.
	costumes ifNotNil:
		[(costumes size > 1 or: [costumes size == 1 and: [costumes first ~~ costume]])
			ifTrue:
				[aMenu add: 'forget other costumes' target: self selector: #forgetOtherCostumes]].
	aMenu addLine.
	aMenu add: 'add a new instance variable' target: self action: #addInstanceVariable.
	"aMenu add: 'add an empty new script' target: aViewer action: #newEmptyScript."
	aMenu add: 'add a new script' target: aViewer action: #newPermanentScript.
	aMenu add: 'expunge empty scripts' target: self action: #expungeEmptyScripts.
	aMenu addLine.
	aMenu add: 'tile representing me' action: #tearOffTileForSelf.
	aMenu add: 'reveal me' target: self selector: #revealPlayerIn: argument: aWorld.
	aMenu add: 'grab me' target: self selector: #grabPlayerIn: argument: aWorld.
	aMenu popUpEvent: aWorld primaryHand lastEvent.
	aMenu addLine.
	aMenu add: 'inspect morph' target: costume selector: #inspect.
	aMenu add: 'inspect player' target: self selector: #inspect.
	self belongsToUniClass ifTrue:
		[aMenu add: 'browse class' target: self action: #browsePlayerClass.
		aMenu add: 'inspect class' target: self class action: #inspect].



"	aMenu add: 'switch costume...' target: self selector: #chooseCostumeIn: argument: aWorld."
"	aMenu add: 'get info...' action: #getInfo.  "

