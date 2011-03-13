Morph
	subclass: #HandMorph
	instanceVariableNames:
		'mouseFocus keyboardFocus eventListeners mouseListeners keyboardListeners mouseClickState mouseOverHandler lastMouseEvent targetOffset damageRecorder cacheCanvas cachedCanvasHasHoles temporaryCursor temporaryCursorOffset hasChanged savedPatch userInitials lastEventBuffer '
	classVariableNames: 'DoubleClickTime EventStats NewEventRules NormalCursor PasteBuffer ShowEvents '
	poolDictionaries: 'EventSensorConstants '
	category: 'Morphic-Kernel'