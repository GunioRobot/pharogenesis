Morph
	subclass: #HandMorph
	instanceVariableNames:
		'mouseFocus keyboardFocus eventListeners mouseListeners keyboardListeners mouseClickState mouseOverHandler lastMouseEvent targetOffset damageRecorder cacheCanvas cachedCanvasHasHoles temporaryCursor temporaryCursorOffset hardwareCursor hasChanged savedPatch userInitials lastEventBuffer genieGestureProcessor keyboardInterpreter'
	classVariableNames:
		'CompositionWindowManager DoubleClickTime EventStats NewEventRules NormalCursor PasteBuffer ShowEvents'
	poolDictionaries: 'EventSensorConstants'
	category: 'Morphic-Kernel'