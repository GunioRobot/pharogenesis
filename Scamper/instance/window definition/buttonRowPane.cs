buttonRowPane
	"Create and return a pane of navigation buttons."

	| buttonRow |
	buttonRow _ AlignmentMorph new
		borderWidth: 0;
		layoutInset: 0;
		hResizing: #spaceFill;
		wrapCentering: #center; cellPositioning: #leftCenter;
		clipSubmorphs: true;
		addTransparentSpacerOfSize: (5@0).
	
	buttonRow 
		addMorphBack: (self simpleButtonNamed: 'Back' translated action: #back text: self backButtonText); 
		addTransparentSpacerOfSize: (5@0);
		addMorphBack: (self simpleButtonNamed: 'Forward' translated action: #forward text: self forwardButtonText); 
		addTransparentSpacerOfSize: (5@0);
		addMorphBack: (self simpleButtonNamed: 'History' translated action: #displayHistory text: self historyButtonText); 
		addTransparentSpacerOfSize: (5@0);
		addMorphBack: (self simpleButtonNamed: 'Reload' translated action: #reload text: self reloadButtonText); 
		addTransparentSpacerOfSize: (5@0);
		addMorphBack: (self simpleButtonNamed: 'Home' translated action: #visitStartPage text: self homeButtonText); 
		addTransparentSpacerOfSize: (5@0);
		addMorphBack: (self simpleButtonNamed: 'Stop!' translated action: #stopEverything text: self stopButtonText); 
		addTransparentSpacerOfSize: (5@0).

	^buttonRow