menu: aMenu shifted: shifted
	^ MenuMorph new
		defaultTarget: self;
		add: 'Inspect (i)' action: #inspectObject;
		balloonTextForLastItem: 'Live long and prosper!';
		addLine;
		add: 'Search again' action: #searchAgain;
		balloonTextForLastItem: 'Search again\for the same object' withCRs;
		yourself