goLevel: aMap 
	"Initialization"
	self select: nil.
	self removeAllMorphs.
	mapMoves _ 0.
	currentMap _ aMap.
	fastMoves
		ifNil: [fastMoves _ currentMap mapStyle isSmallScreen].
	bounds _ self position corner: self position.
	"creates new controls"
	self createTextBars.
	self createButtonsBar.
	self createMaze.
	self createPreview.
	"information"
	self showPointsInfo.
	"select the first atom"
	self select: self nextMolecule