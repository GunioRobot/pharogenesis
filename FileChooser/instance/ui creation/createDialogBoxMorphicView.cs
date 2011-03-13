createDialogBoxMorphicView
	| m |
	m := MorphicModel new
		layoutPolicy: ProportionalLayout new;
		color: Preferences menuColor;
		borderColor: Preferences menuBorderColor;
		borderWidth: Preferences menuBorderWidth;
		layoutInset: 0;
		extent: 600@400.
	self setMorphicView: m.
	^m