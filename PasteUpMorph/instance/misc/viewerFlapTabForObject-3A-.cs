viewerFlapTabForObject: anObject
	"Open up a Viewer on anObject in its own flap, creating it if necessary.  This is the viewer-for-any-object version of this method, but in the current corpus of code is not hooked up."

	| bottomMost aFlapTab |
	bottomMost _ 0.
	self flapTabs do:
		[:aTab | (aTab isKindOf: ViewerFlapTab)
			ifTrue:
				[bottomMost _ aTab bottom max: bottomMost.
				aTab scriptedPlayer == anObject
					ifTrue:
						[^ aTab]]].
	"Not found; make a new one"
	aFlapTab _ (Utilities newFlapTitled: anObject externalName onEdge: #right) as: ViewerFlapTab.
	aFlapTab initializeFor: anObject topAt: bottomMost + 2.
	aFlapTab referent color: (Color green muchLighter alpha: 0.5).
	aFlapTab referent setProperty: #automaticPhraseExpansion toValue: true.
	self addMorphFront: aFlapTab.
	aFlapTab adaptToWorld: self.
	^ aFlapTab