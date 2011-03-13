standardBottomFlap
	"Answer a fully-instantiated flap named 'Supplies' to be placed at the bottom of the screen"

	|  aFlapTab aPage |
	aPage _ self newPartsFlapPage.
	aPage setProperty: #maximumThumbnailWidth toValue: 80.
	aFlapTab _ FlapTab new referent: aPage beSticky.
	aFlapTab color: Color red lighter.
	aFlapTab setToPopOutOnDragOver: true.
	aFlapTab setToPopOutOnMouseOver: true.
	aFlapTab assumeString: 'Supplies' font: Preferences standardFlapFont orientation: #horizontal color: Color red lighter.
	aFlapTab edgeToAdhereTo: #bottom; inboard: false.

	aPage extent: self currentWorld width @ 100.

	aPage addMorphBack: Command undoRedoButtons markAsPartsDonor.
	aPage addMorphBack: TrashCanMorph new markAsPartsDonor.
	aPage addMorphBack: ScriptingSystem scriptControlButtons markAsPartsDonor.

	#(PaintInvokingMorph RectangleMorph EllipseMorph StarMorph  CurveMorph PolygonMorph TextMorph ) do:
		[:sym | aPage addMorphBack: (Smalltalk at: sym) authoringPrototype].

	aPage addMorphBack: ScriptingSystem prototypicalHolder.
	aPage addMorphBack: RectangleMorph roundRectPrototype.

	#(ImageMorph ScriptableButton SimpleSliderMorph
		PasteUpMorph   BookMorph TabbedPalette 
		JoystickMorph  ) do:
		[:sym | aPage addMorphBack: (Smalltalk at: sym) authoringPrototype].

	aPage addMorphBack: Morph new previousPageButton markAsPartsDonor.
	aPage addMorphBack: Morph new nextPageButton markAsPartsDonor.
	aPage addMorphBack: ScriptingSystem holderWithAlphabet markAsPartsDonor.
	aPage addMorphBack: (ClockMorph authoringPrototype showSeconds: false) step.

	aPage replaceTallSubmorphsByThumbnails.

	aFlapTab position: ((Display width - aFlapTab width) // 2 @ (self currentWorld height - aFlapTab height)).
	aPage beFlap: true.
	aPage color: (Color red muchLighter "alpha: 0.2").
	aPage extent: self currentWorld width @ 100.
	
	^ aFlapTab