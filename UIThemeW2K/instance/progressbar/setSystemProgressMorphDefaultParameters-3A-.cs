setSystemProgressMorphDefaultParameters: aProgressMorph

	aProgressMorph color: self backgroundColor.
	aProgressMorph borderWidth: Preferences menuBorderWidth.
	aProgressMorph borderStyle: BorderStyle thinGray.
	aProgressMorph
			addDropShadow;
			shadowColor: (TranslucentColor r: 0.0 g: 0.0 b: 0.0 alpha: 0.666);
			shadowOffset: 1 @ 1