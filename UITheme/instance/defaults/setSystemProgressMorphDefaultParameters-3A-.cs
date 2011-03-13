setSystemProgressMorphDefaultParameters: aProgressMorph
	"Set up the given progress morph."

	| colorFromMenu worldColor menuColor |
	colorFromMenu := Preferences menuColorFromWorld
									and: [Display depth > 4]
									and: [(worldColor := aProgressMorph currentWorld color) isColor].
	menuColor := colorFromMenu
						ifTrue: [worldColor luminance > 0.7
										ifTrue: [worldColor mixed: 0.85 with: Color black]
										ifFalse: [worldColor mixed: 0.4 with: Color white]]
						ifFalse: [Preferences menuColor].
	aProgressMorph color: menuColor.
	Preferences roundedMenuCorners
		ifTrue: [aProgressMorph useRoundedCorners].
	aProgressMorph borderWidth: Preferences menuBorderWidth.
	Preferences menuAppearance3d
		ifTrue: [aProgressMorph borderStyle: BorderStyle thinGray.
				aProgressMorph
					addDropShadow;
					shadowColor: (TranslucentColor r: 0.0 g: 0.0 b: 0.0 alpha: 0.666);
					shadowOffset: 1 @ 1]
	ifFalse: [| menuBorderColor |
			menuBorderColor := colorFromMenu
				ifTrue: [worldColor muchDarker]
				ifFalse: [Preferences menuBorderColor].
			aProgressMorph borderColor: menuBorderColor].
	aProgressMorph
		updateColor: aProgressMorph
		color: aProgressMorph color
		intensity: 1