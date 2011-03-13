Morph
	subclass: #HandMorph
	instanceVariableNames:
		'mouseFocus keyboardFocus eventListeners mouseListeners keyboardListeners mouseClickState mouseOverHandler lastMouseEvent targetOffset damageRecorder cacheCanvas cachedCanvasHasHoles temporaryCursor temporaryCursorOffset hardwareCursor hasChanged savedPatch userInitials lastEventBuffer lastKeyScanCode combinedChar'
	classVariableNames:
		'CompositionWindowManager DoubleClickTime EventStats NormalCursor PasteBuffer ShowEvents VirtualKeys'
	poolDictionaries: 'EventSensorConstants'
	category: 'Morphic-Kernel'