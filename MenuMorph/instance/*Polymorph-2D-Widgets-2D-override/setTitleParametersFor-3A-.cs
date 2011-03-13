setTitleParametersFor: aMenuTitle 
	| menuTitleColor menuTitleBorderColor |
	Preferences roundedMenuCorners
		ifTrue: [aMenuTitle useRoundedCorners].

	menuTitleColor := Preferences menuColorFromWorld
				ifTrue: [self color darker]
				ifFalse: [self theme menuTitleColorFor: 
						((UIManager default respondsTo: #modalMorph)
							ifTrue: [UIManager default modalMorph]
							ifFalse: [nil])].

	menuTitleBorderColor := Preferences menuAppearance3d
				ifTrue: [#inset]
				ifFalse: [Preferences menuColorFromWorld
						ifTrue: [self color darker muchDarker]
						ifFalse: [Preferences menuTitleBorderColor]].

	aMenuTitle
		setColor: menuTitleColor
		borderWidth: 0
		borderColor: menuTitleBorderColor;
		vResizing: #shrinkWrap;
		wrapCentering: #center;
		cellPositioning: #topCenter;
		layoutInset: 0.
