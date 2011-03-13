standardRightFlap
	"Answer a newly-created flap which adheres to the right edge of the screen and which holds prototypes of standard tools"

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

  "This hard-coded list is regrettable but expedient"
	#('System Browser' 'Package Browser' 'Workspace' 'File List' 'Dual Change Sorter' 'Single Change Sorter' 'Selector Browser' 'Assembly Area' 'Scripting Area' 'Sound Recorder') doWithIndex: 
		[:help :index |
			(aPage submorphs at: index) setBalloonText: help].

	aFlapTab position: (self currentWorld width - aFlapTab width) @ ((Display height - aFlapTab height) // 2).
	aPage beFlap: true.
	aPage color: (Color brown muchLighter alpha: 0.5).
	aPage extent: (90 @ self currentWorld height).
	
	^ aFlapTab