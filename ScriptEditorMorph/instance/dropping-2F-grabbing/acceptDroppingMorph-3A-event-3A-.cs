acceptDroppingMorph: aMorph event: evt
	"Allow the user to add tiles and program fragments just by dropping them on this morph." 
	| i slideMorph p1 p2 |	
	self prepareToUndoDropOf: aMorph.
	
	"Find where it will go, and prepare to animate the move..."
	i _ self rowInsertionIndexFor: aMorph fullBounds center.
	slideMorph _ aMorph imageForm offset: 0@0.
	p1 _ aMorph screenRectangle topLeft.
	aMorph delete.
	self stopStepping.
	self world displayWorld.  "Clear old image prior to animation"

	(aMorph isKindOf: PhraseTileMorph) ifTrue: [aMorph unbrightenTiles].
	aMorph tileRows do: [:tileList |
		self insertTileRow: (Array with:
				(tileList first rowOfRightTypeFor: owner forActor: aMorph associatedPlayer))
			after: i.
		i _ i + 1].
	self removeSpaces.
	self enforceTileColorPolicy.
	self layoutChanged.

	"Now animate the move, before next Morphic update.
		NOTE: This probably should use ZoomMorph instead"
	p2 _ (self submorphs atPin: (i-1 max: firstTileRow)) screenRectangle topLeft.
	slideMorph slideFrom: p1 to: p2 nSteps: 5 delay: 50 andStay: true.
	self playSoundNamed: 'scritch'.
	self topEditor install  "Keep me for editing, a copy goes into lastAcceptedScript"

