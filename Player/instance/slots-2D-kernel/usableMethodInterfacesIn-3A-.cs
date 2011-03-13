usableMethodInterfacesIn: methodInterfaceList
	"Filter the list given by methodInterfaceList, to remove items inappropriate to the receiver"

	self hasCostumeThatIsAWorld ifTrue:
		[^ methodInterfaceList select: [:anInterface |
			#(append: prepend: beep: clearTurtleTrails doScript: getColor "color" getCursor "cursor" deleteCard doMenuItem emptyScript firstPage goToFirstCardInBackground goToFirstCardOfStack goToLastCardInBackground goToLastCardOfStack goToNextCardInStack goToPreviousCardInStack initiatePainting insertCard  liftAllPens lowerAllPens trailStyleForAllPens: arrowheadsOnAllPens noArrowheadsOnAllPens getMouseX getMouseY "mouseX mouseY" pauseScript: reverse roundUpStrays shuffleContents startScript: stopScript: unhideHiddenObjects getValueAtCursor "valueAtCursor"
startAll: pauseAll: stopAll:  
viewAllMessengers clobberAllMessengers openAllScriptsTool handScriptControlButtons viewAllReferencedObjects jumpToProject: #getLength #getWidth )

includes: anInterface selector]].

	self hasAnyBorderedCostumes ifTrue: [^ methodInterfaceList].

	^ self hasOnlySketchCostumes
		ifTrue:
			[methodInterfaceList select: [:anInterface | (#(getColor getAlpha getSecondColor getBorderColor getBorderWidth getBorderStyle getRoundedCorners getUseGradientFill getRadialGradientFill ) includes: anInterface selector) not]]
		ifFalse:
			[methodInterfaceList select: [:anInterface | (#(getBorderColor getBorderWidth) includes: anInterface selector) not]]