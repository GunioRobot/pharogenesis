addTilesTab
	| aPage |
	aPage _ self presenter tilesPagesForPartsBin first.
	aPage extent: pageSize.
	aPage setNameTo: 'tiles'.
	self addTabForBook: aPage withBalloonText: 'useful tiles for scripting'
