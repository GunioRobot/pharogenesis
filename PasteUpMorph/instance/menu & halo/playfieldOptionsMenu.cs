playfieldOptionsMenu
	"Answer an auxiliary menu with options specific to playfields -- too many to be housed in the main menu"

	| aMenu isWorld |
	isWorld := self isWorldMorph.
	aMenu := MenuMorph new defaultTarget: self.
	aMenu addStayUpItem.
	
	aMenu add: 'round up strays' translated action: #roundUpStrays.
	aMenu balloonTextForLastItem:  'Bring back all objects whose current coordinates keep them from being visible, so that at least a portion of each of my interior objects can be seen.' translated.

	
	self griddingOn
		ifTrue: [aMenu add: 'turn gridding off' translated action: #griddingOnOff.
				aMenu add: (self gridVisible ifTrue: ['hide'] ifFalse: ['show']) translated, ' grid' translated
						action: #gridVisibleOnOff.
				aMenu add: 'set grid spacing...' translated action: #setGridSpec]
		ifFalse: [aMenu add: 'turn gridding on' translated action: #griddingOnOff].
	aMenu addLine.

	#(	(autoLineLayoutString	toggleAutoLineLayout
			'whether submorphs should automatically be laid out in lines')
		(indicateCursorString	toggleIndicateCursor
			'whether the "current" submorph should be indicated with a dark black border')
		(isPartsBinString		toggleIsPartsBin
			'whether dragging an object from the interior should produce a COPY of the object')
		(isOpenForDragNDropString	toggleDragNDrop
			'whether objects can be dropped into and dragged out of me')
		(mouseOverHalosString	toggleMouseOverHalos
			'whether objects should put up halos when the mouse is over them')
		(originAtCenterString	toggleOriginAtCenter
			'whether the cartesian origin of the playfield should be at its lower-left corner or at the center of the playfield')
	) do:

			[:triplet |
				(isWorld and: [#(toggleAutoLineLayout toggleIndicateCursor toggleIsPartsBin) includes: triplet second]) ifFalse:
					[aMenu addUpdating: triplet first action: triplet second.
					aMenu balloonTextForLastItem: triplet third translated]]. 

	
	((isWorld not or: [self backgroundSketch notNil]) or: [presenter isNil])
		ifTrue:
			[aMenu addLine].

	self backgroundSketch ifNotNil:
		[aMenu add: 'delete background painting' translated action: #deleteBackgroundPainting.
		aMenu balloonTextForLastItem: 'delete the graphic that forms the background for this me.' translated].
	aMenu addLine.
	aMenu add: 'use standard texture' translated action: #setStandardTexture.
	aMenu balloonTextForLastItem: 'use a pale yellow-and-blue background texture here.' translated.
	aMenu add: 'make graph paper...' translated action: #makeGraphPaper.
	aMenu balloonTextForLastItem: 'Design your own graph paper and use it as the background texture here.' translated.
	aMenu addTitle: 'playfield options...' translated.

	^ aMenu
