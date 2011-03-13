setTitleParametersFor: aMenuTitle 
	| menuTitleColor menuTitleBorderColor |
	Preferences roundedMenuCorners
		ifTrue: [aMenuTitle useRoundedCorners].

	menuTitleColor := Preferences menuColorFromWorld
				ifTrue: [self color darker]
				ifFalse: [Preferences menuTitleColor].

	menuTitleBorderColor := Preferences menuAppearance3d
				ifTrue: [#inset]
				ifFalse: [Preferences menuColorFromWorld
						ifTrue: [self color darker muchDarker]
						ifFalse: [Preferences menuTitleBorderColor]].

	aMenuTitle
		setColor: menuTitleColor
		borderWidth: Preferences menuTitleBorderWidth
		borderColor: menuTitleBorderColor;
		vResizing: #shrinkWrap;
		wrapCentering: #center;
		cellPositioning: #topCenter;
		layoutInset: 0.
