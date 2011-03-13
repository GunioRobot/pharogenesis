showSourceInScriptor
	"Remove tile panes, if any, and show textual source instead"

	| aCodePane |

	self isTextuallyCoded ifFalse: [self becomeTextuallyCoded].
		"Mostly to fix up grandfathered ScriptEditors"

	self submorphs allButFirst do: [:m | m delete].

	aCodePane _ MethodHolder 
		isolatedCodePaneForClass: playerScripted class 
		selector: scriptName.

	aCodePane
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		minHeight: 100.
	self 
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap.
	self addMorphBack: aCodePane.
	self fullBounds.
	self 
		listDirection: #topToBottom;
		hResizing: #rigid;
		vResizing: #rigid;
		rubberBandCells: true;
		minWidth: self width.

	showingMethodPane _ true.
	(playerScripted isUniversalTiles) ifTrue: [self useNewTilesNow].
			"grab aCodePane, get model, and remove it" 

	self currentWorld startSteppingSubmorphsOf: self