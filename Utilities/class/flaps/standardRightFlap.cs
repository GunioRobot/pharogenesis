standardRightFlap
	|  aFlapTab aPage |
	aPage _ self newPartsFlapPage.
	aFlapTab _ FlapTab new referent: aPage beSticky.
	aFlapTab color: Color red lighter.
	aFlapTab assumeString: 'Tools' font: Preferences standardFlapFont orientation: #vertical color: Color orange lighter.
	aFlapTab edgeToAdhereTo: #right; inboard: false.
	aFlapTab setToPopOutOnDragOver: true.
	aFlapTab setToPopOutOnMouseOver: true.

	aPage extent: (90 @ self currentWorld height).
	self addSampleWindowsTo: aPage.
	aPage addMorphBack: ScriptingSystem newScriptingSpace.
	aPage addMorphBack: RecordingControlsMorph authoringPrototype.
	aPage replaceTallSubmorphsByThumbnails.
	aPage fixLayout.

	aFlapTab position: (self currentWorld width - aFlapTab width) @ ((Display height - aFlapTab height) // 2).
	aPage setProperty: #flap toValue: true.
	aPage color: (Color brown muchLighter alpha: 0.5).
	aPage extent: (90 @ self currentWorld height).
	
	^ aFlapTab