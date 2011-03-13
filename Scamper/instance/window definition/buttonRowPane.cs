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
		addMorphBack: (self simpleButtonNamed: 'Back' action: #back text: self backButtonText); 
		addTransparentSpacerOfSize: (5@0);
		addMorphBack: (self simpleButtonNamed: 'Forward' action: #forward text: self forwardButtonText); 
		addTransparentSpacerOfSize: (5@0);
		addMorphBack: (self simpleButtonNamed: 'History' action: #displayHistory text: self historyButtonText); 
		addTransparentSpacerOfSize: (5@0);
		addMorphBack: (self simpleButtonNamed: 'Reload' action: #reload text: self reloadButtonText); 
		addTransparentSpacerOfSize: (5@0);
		addMorphBack: (self simpleButtonNamed: 'Home' action: #visitStartPage text: self homeButtonText); 
		addTransparentSpacerOfSize: (5@0);
		addMorphBack: (self simpleButtonNamed: 'Stop!' action: #stopEverything text: self stopButtonText); 
		addTransparentSpacerOfSize: (5@0).

	^buttonRow