viewerFlapTabFor: anObject
	"Open up a Viewer on aMorph in its own flap, creating it if necessary"

	| bottomMost aPlayer aFlapTab tempFlapTab |
	bottomMost _ self top.
	aPlayer _ anObject isMorph ifTrue: [anObject assuredPlayer] ifFalse: [anObject objectRepresented].
	self flapTabs do:
		[:aTab | ((aTab isKindOf: ViewerFlapTab) or: [aTab hasProperty: #paintingFlap])
			ifTrue:
				[bottomMost _ aTab bottom max: bottomMost.
				((aTab isKindOf: ViewerFlapTab) and: [aTab scriptedPlayer == aPlayer])
					ifTrue:
						[^ aTab]]].
	"Not found; make a new one"
	tempFlapTab _ Flaps newFlapTitled: anObject nameForViewer onEdge: #right inPasteUp: self.
	tempFlapTab arrangeToPopOutOnDragOver: false;
		arrangeToPopOutOnMouseOver: false. 
	"For some reason those event handlers were causing trouble, as reported by ar 11/22/2001, after di's flapsOnBottom update."
	aFlapTab _ tempFlapTab as: ViewerFlapTab.

	aFlapTab initializeFor: aPlayer topAt: bottomMost + 2.
	aFlapTab referent color: (Color green muchLighter alpha: 0.5).
	aFlapTab referent borderWidth: 0.
	aFlapTab referent setProperty: #automaticPhraseExpansion toValue: true.
	Preferences compactViewerFlaps 
		ifTrue:	[aFlapTab makeFlapCompact: true].
	self addMorphFront: aFlapTab.
	aFlapTab adaptToWorld: self.
	aFlapTab setProperty: #isEToysFlap toValue: true.
	^ aFlapTab