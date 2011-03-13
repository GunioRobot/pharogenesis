presentViewMenu
	"Answer an auxiliary menu with options specific to viewing playfields -- this is put up from the provisional 'view' halo handle, on pasteup morphs only."

	| aMenu isWorld |
	isWorld := self isWorldMorph.
	aMenu := MenuMorph new defaultTarget: self.
	aMenu addStayUpItem.
	self addViewingItemsTo: aMenu.

	#( (indicateCursorString	toggleIndicateCursor
			'whether the "current" submorph should be indicated with a dark black border')
		(resizeToFitString		toggleResizeToFit
			'whether I should automatically strive exactly to fit my contents')
		(behaveLikeAHolderString	toggleBehaveLikeAHolder
			'whether auto-line-layout, resize-to-fit, and indicate-cursor should be set to true; useful for animation control, etc.')
		(isPartsBinString		toggleIsPartsBin
			'whether dragging an object from the interior should produce a COPY of the object')
		(isOpenForDragNDropString	toggleDragNDrop
			'whether objects can be dropped into and dragged out of me')
		(mouseOverHalosString	toggleMouseOverHalos
			'whether objects should put up halos when the mouse is over them')
		(originAtCenterString	toggleOriginAtCenter
			'whether the cartesian origin of the playfield should be at its lower-left corner or at the center of the playfield')
		(griddingString			griddingOnOff
			'whether gridding should be used in my interior')
		(gridVisibleString		gridVisibleOnOff
			'whether the grid should be shown when gridding is on')


	) do:

			[:triplet |
				(isWorld and: [#(toggleAutoLineLayout toggleIndicateCursor toggleIsPartsBin) includes: triplet second]) ifFalse:
					[aMenu addUpdating: triplet first action: triplet second.
					aMenu balloonTextForLastItem: triplet third translated]]. 

	aMenu addLine.
	aMenu add: 'round up strays' translated action: #roundUpStrays.
	aMenu balloonTextForLastItem:  'Bring back all objects whose current coordinates keep them from being visible, so that at least a portion of each of my interior objects can be seen.' translated.
	aMenu add: 'shuffle contents' translated action: #shuffleSubmorphs.
	aMenu balloonTextForLastItem: 'Rearranges my contents in random order' translated.
	aMenu add: 'set grid spacing...' translated action: #setGridSpec.
	aMenu balloonTextForLastItem: 'Set the spacing to be used when gridding is on' translated.

	self backgroundSketch ifNotNil:
		[aMenu add: 'delete background painting' translated action: #deleteBackgroundPainting.
		aMenu balloonTextForLastItem: 'delete the graphic that forms the background for this me.' translated].
	aMenu addLine.
	aMenu add: 'use standard texture' translated action: #setStandardTexture.
	aMenu balloonTextForLastItem: 'use a pale yellow-and-blue background texture here.' translated.
	aMenu add: 'make graph paper...' translated action: #makeGraphPaper.
	aMenu balloonTextForLastItem: 'Design your own graph paper and use it as the background texture here.' translated.
	aMenu addTitle: ('viewing options for "{1}"' translated format: {self externalName}).

	aMenu popUpForHand: self activeHand in: self world
