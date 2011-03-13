addStayUpIcons
	| title closeBox pinBox titleBarArea titleString |
	title _ submorphs
				detect: [:ea | ea hasProperty: #titleString]
				ifNone: [self setProperty: #needsTitlebarWidgets toValue: true.
					^ self].
	closeBox _ IconicButton new target: self;
				 actionSelector: #delete;
				 labelGraphic: self class closeBoxImage;
				 color: Color transparent;
				 extent: 14 @ 16;
				 borderWidth: 0.
	pinBox _ IconicButton new target: self;
				 actionSelector: #stayUp:;
				 arguments: {true};
				 labelGraphic: self class pushPinImage;
				 color: Color transparent;
				 extent: 14 @ 15;
				 borderWidth: 0.
	Preferences noviceMode
		ifTrue: [closeBox setBalloonText: 'close this menu'.
			pinBox setBalloonText: 'keep this menu up'].
	titleBarArea _  AlignmentMorph newRow vResizing: #shrinkWrap;
			 layoutInset: 3;
			 color: Preferences menuTitleColor;
			 addMorphBack: closeBox;
			 addMorphBack: title;
			 addMorphBack: pinBox.
	
	title color: Color transparent.

	titleString _ title 
		findDeepSubmorphThat: [:each | each respondsTo: #font: ]
		ifAbsent: [nil].
	titleString font: Preferences windowTitleFont.
	Preferences roundedMenuCorners
		ifTrue: [titleBarArea useRoundedCorners].
	
	self addMorphFront: titleBarArea.
	titleBarArea setProperty: #titleString toValue: (title valueOfProperty: #titleString).
	title removeProperty: #titleString.
	self setProperty: #hasTitlebarWidgets toValue: true.
	self removeProperty: #needsTitlebarWidgets.
	self removeStayUpItems