viewerFlapTabFor: aMorph
	"Open up a Viewer on aMorph in its own flap, creating it if necessary"
	| bottomMost aPlayer aFlapTab |
	bottomMost _ 0.
	aPlayer _ aMorph assuredPlayer.
	self flapTabs do:
		[:aTab | (aTab isKindOf: ViewerFlapTab)
			ifTrue:
				[bottomMost _ aTab bottom max: bottomMost.
				aTab scriptedPlayer == aPlayer
					ifTrue:
						[^ aTab]]].
	"Not found; make a new one"
	aFlapTab _ (Utilities newFlapTitled: aMorph externalName onEdge: #right) as: ViewerFlapTab.
	aFlapTab initializeFor: aPlayer topAt: bottomMost + 2.
	aFlapTab referent color: (Color green muchLighter alpha: 0.5).
	aFlapTab referent setProperty: #automaticPhraseExpansion toValue: true.
	self addMorphFront: aFlapTab.
	aFlapTab adaptToWorld: self.
	^ aFlapTab