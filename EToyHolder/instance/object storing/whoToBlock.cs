whoToBlock
	"Return a IdentityDictionary of objects that we block or change on the way to the disk.  In addition to the substitutions in objectToStoreOnDataStream"

	"Prep for saving"
	| blockers tabBook |
	playfield setProperty: #worldSize toValue: playfield world extent.	"world is nil later"
	blockers _ IdentityDictionary new.
	blockers at: playfield world put: nil.		"Don't write the world"
	eToyPalette ifNil: [self halt.  "playfield no longer has own copy of the etoy palette" eToyPalette _ playfield eToyPalette].	"backward compat"
		"EToyPalette blocks all but userScraps"
	"playfield turtleTrails and pen not blocked"
	self actorsOutsidePlayfield.	"save them"

	"For standard scaffolding tabs, put a dummy into the blockers dict."
	self tabsNotToStore do: [:quad | 
		tabBook _ scaffoldingBook objectAtTab: quad first.
		tabBook ifNotNil: [
			blockers at: tabBook
				put: (scaffoldingBook clobberContentsOfTabNamed: quad first)]].

	self trimScaffoldingBookBeforeSaving.
		"Does not trim.  Only asks if scripts in scaffolding book should be dropped"
	^ blockers
