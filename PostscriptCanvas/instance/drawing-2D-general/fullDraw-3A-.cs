fullDraw:aMorph
	"self comment:'begin morph: ' with:aMorph."
	self comment:'level: ' with:morphLevel.
	morphLevel_morphLevel+1.
	self gsave.
	self setupGStateForMorph:aMorph.
	aMorph fullDrawPostscriptOn:self.
	self grestore.
	morphLevel_morphLevel-1.
	self comment:'end morph: ' with:aMorph.
	self comment:'level: ' with:morphLevel.	