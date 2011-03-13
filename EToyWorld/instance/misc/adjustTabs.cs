adjustTabs
	"Get the tabs names right"
	| but tabHeight  aTitle projects which balloonText |
	tabHeight _ 15.
	tabs removeAllMorphs.
	projects _ ScheduledControllers scheduledWindowControllers
		select: [:c | c view isKindOf: ProjectView]
		thenCollect: [:c | c model].
	projects doWithIndex: [:project :ind |
		aTitle _ project name.
		but _ tabs addButtonShowing: aTitle, '              '
			named: aTitle selector: #selectTabNamed: 
			arguments: (Array with: aTitle) atIndex: ind.
		but font: (StrikeFont familyName: 'ComicBold' size: 16).
		but extent: (but extent x @ tabHeight).
		(which _ #('Imagineers' 'Etoys') indexOf: aTitle ifAbsent: [0]) > 0
			ifTrue:
			[balloonText _
#('Would you like to meet some other imagineers?
Click here!'
'Click here to explore the world of EToys!') at: which.
			but setBalloonText: balloonText]].

	"Change its background color?"
	tabs color: Color transparent; borderWidth: 0.
