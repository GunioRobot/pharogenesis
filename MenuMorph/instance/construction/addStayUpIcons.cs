addStayUpIcons
	| title closeBox pinBox |
	title := submorphs
				detect: [:ea | ea hasProperty: #titleString]
				ifNone: [self setProperty: #needsTitlebarWidgets toValue: true.
					^ self].
	closeBox := IconicButton new target: self;
				 actionSelector: #delete;
				 labelGraphic: self class closeBoxImage;
				 color: Color transparent;
				 extent: 14 @ 16;
				 borderWidth: 0.
	pinBox := IconicButton new target: self;
				 actionSelector: #stayUp:;
				 arguments: {true};
				 labelGraphic: self class pushPinImage;
				 color: Color transparent;
				 extent: 14 @ 15;
				 borderWidth: 0.
	Preferences noviceMode
		ifTrue: [closeBox setBalloonText: 'close this menu'.
			pinBox setBalloonText: 'keep this menu up'].
	self addMorphFront: (AlignmentMorph newRow vResizing: #shrinkWrap;
			 layoutInset: 0;
			 color: Color transparent"Preferences menuTitleColor";
			 addMorphBack: closeBox;
			 addMorphBack: title;
			 addMorphBack: pinBox).
	self setProperty: #hasTitlebarWidgets toValue: true.
	self removeProperty: #needsTitlebarWidgets.
	self removeStayUpItems