storeDataOn: aDataStream
	"Write myself out on the disk.  Block out all palettes except the user's Scraps.  Empty the trash. prepareToBeSaved has already released caches."

	self emptyTrash.
	aDataStream blockers at: viewPalette put: nil.
	aDataStream blockers at: widgetsPalette put: nil.
	aDataStream blockers at: suppliesPalette put: nil.
	aDataStream blockers at: controlsPalette put: nil.
	"aDataStream blockers at: partsBank put: nil.		just a number"
	"aDataStream blockers at: scriptsBank put: nil.		just a number"
	aDataStream blockers removeKey: nil ifAbsent: [].
	^ super storeDataOn: aDataStream