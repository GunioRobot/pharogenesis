addPartsTab
	| partsBook aPage |
	partsBook _ BookMorph new pageSize: pageSize; setNameTo: 'supplies'.
	partsBook removeEverything.
	aPage _ self presenter newPageForStandardPartsBin.
	aPage extent: pageSize.
	#(PaintInvokingMorph RectangleMorph EllipseMorph StarMorph  CurveMorph PolygonMorph TextMorph ImageMorph
		PasteUpMorph JoystickMorph SimpleSliderMorph) do:
		[:sym | aPage addMorphBack: (Smalltalk at: sym) authoringPrototype].
	aPage addMorphBack: RectangleMorph roundRectPrototype.
	aPage addMorphBack: ScriptingSystem prototypicalHolder.
	aPage replaceTallSubmorphsByThumbnails.
	aPage setPartsBinStatusTo: true.
	aPage fixLayout.
	partsBook insertPage: aPage pageSize: pageSize.
	self addTabForBook: partsBook withBalloonText: 'parts bin'