viewerFlapTabFor: anObject
	"Open up a Viewer on aMorph in its own flap, creating it if necessary"

	| bottomMost aPlayer aFlapTab |
	bottomMost _ self top.
	aPlayer _ anObject isMorph ifTrue: [anObject assuredPlayer] ifFalse: [anObject objectRepresented].
	self flapTabs do:
		[:aTab | (aTab isKindOf: ViewerFlapTab)
			ifTrue:
				[bottomMost _ aTab bottom max: bottomMost.
				aTab scriptedPlayer == aPlayer
					ifTrue:
						[^ aTab]]].
	"Not found; make a new one"
	aFlapTab _ (Utilities newFlapTitled: anObject nameForViewer onEdge: #right inPasteUp: self)
		as: ViewerFlapTab.
	aFlapTab initializeFor: aPlayer topAt: bottomMost + 2.
	aFlapTab referent color: (Color green muchLighter alpha: 0.5).
	aFlapTab referent borderWidth: 0.
	aFlapTab referent setProperty: #automaticPhraseExpansion toValue: true.
	Preferences compactViewerFlaps 
		ifTrue:[aFlapTab makeFlapCompact: true].
	self addMorphFront: aFlapTab.
	aFlapTab adaptToWorld: self.
	^ aFlapTab