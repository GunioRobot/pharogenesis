Morph
	subclass: #HandMorph
	instanceVariableNames:
		'eventSubscribers keyboardFocus mouseDownMorph mouseOverMorphs mouseOverTimes clickClient clickState firstClickEvent firstClickTime userInitials lastEvent eventTransform argument targetOffset damageRecorder cacheCanvas cachedCanvasHasHoles temporaryCursor temporaryCursorOffset grid gridOn remoteConnections transmitBuffer lastEventTransmitted lastWorldExtent menuTargetOffset hasChanged savedPatch suppressDrawing formerOwner formerPosition '
	classVariableNames: 'DoubleClickTime NormalCursor PasteBuffer '
	poolDictionaries: ''
	category: 'Morphic-Kernel'