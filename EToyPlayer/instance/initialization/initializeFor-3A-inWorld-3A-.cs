initializeFor: anEToyHolder inWorld: aWorld
	"Prepare the receiver to present the given EToy in the given world."
	"Note: Any existing morphs are removed from the given world first."

	| m leftEdge rightEdge sizeWanted ok |
	associatedMorph _ aWorld.
	aWorld removeAllMorphs.
	self standardHolder: anEToyHolder.
	aWorld presenter: self.
	
	aWorld addEToy: anEToyHolder.
	self initializeToggles.

	aWorld addMorph: anEToyHolder scaffoldingBook beSticky.
	leftEdge _ anEToyHolder scaffoldingBook right - 1.
	rightEdge _ aWorld width - 185.

	m _ anEToyHolder playfield.
	sizeWanted _ m valueOfProperty: #worldSize.
	ok _ sizeWanted ifNil: [false] ifNotNil:
		[(aWorld extent x >= sizeWanted x) & (aWorld extent y >= sizeWanted y)].
	ok ifFalse: ["size not remembered"
		m extent: (rightEdge - leftEdge)@(aWorld height//2).
		m color: self initialPlayfieldColor].
	aWorld addMorphBack: (m position: leftEdge@0).

	aWorld startSteppingSubmorphsOf: m.
	m _ anEToyHolder eToyPalette.
	m ifNil: [m _ EToyPalette new].
	anEToyHolder eToyPalette: m.
	standardPalette _ m.

	aWorld addMorph: (m beSticky position: anEToyHolder playfield right-1 @0).
	m initializeInWorld: aWorld.  "So palettes can get at world"
	m showNoPalette.
	self harmonizeTilesWithColorSetting.

	self addControlsFor: anEToyHolder inWorld:  aWorld.
	anEToyHolder notInPlayfield 
		ifNil: [self addExtrasFor: anEToyHolder 
					inWorld: aWorld]  "differs from orig 118tk here"
		ifNotNil: [anEToyHolder notInPlayfield reverseDo: [:each | aWorld addMorph: each]].

	anEToyHolder scaffoldingBook selectTabNamed: 'Toy'.
	EToyParameters kidsMode ifTrue:
		[anEToyHolder scaffoldingBook configureForKids].

	self startRunningScripts