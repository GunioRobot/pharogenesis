playfieldOptionsMenu
	"Answer an auxiliary menu with options specific to playfields -- too many to be housed in the main menu"

	| aMenu isWorld |
	isWorld _ self isWorldMorph.
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addStayUpItem.
	aMenu add: 'save on file...' translated action: #saveOnFile.
	aMenu add: 'save as SqueakPage at url...' translated action: #saveOnURL.
	aMenu add: 'update all from resources' translated action: #updateAllFromResources.
	(self valueOfProperty: #classAndMethod) ifNotNil:
		[aMenu add: 'broadcast as documentation' translated action: #saveDocPane].
	aMenu add: 'round up strays' translated action: #roundUpStrays.
	aMenu balloonTextForLastItem:  'Bring back all objects whose current coordinates keep them from being visible, so that at least a portion of each of my interior objects can be seen.' translated.
	aMenu add: 'show all players' translated action: #showAllPlayers.
	aMenu balloonTextForLastItem:  'Make visible the viewers for all players which have user-written scripts in this playfield.' translated.
	aMenu add: 'hide all players' translated action: #hideAllPlayers.
	aMenu balloonTextForLastItem:  'Make invisible the viewers for all players in this playfield. This will save space before you publish this project' translated.


	aMenu addLine.
	aMenu add: 'shuffle contents' translated action: #shuffleSubmorphs.
	aMenu balloonTextForLastItem: 'Rearranges my contents in random order' translated.
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
		(autoExpansionString	toggleAutomaticPhraseExpansion
			'whether tile phrases, dropped on me, should automatically sprout Scriptors around them')
		(originAtCenterString	toggleOriginAtCenter
			'whether the cartesian origin of the playfield should be at its lower-left corner or at the center of the playfield')
		(showThumbnailString	toggleAlwaysShowThumbnail
			'whether large objects should be represented by thumbnail miniatures of themselves')
		(fenceEnabledString	toggleFenceEnabled
			'whether moving objects should stop at the edge of their container')
		(batchPenTrailsString	toggleBatchPenTrails 
			'if true, detailed movement of pens between display updates is ignored.  Thus multiple line segments drawn within a script may not be seen individually.')

	) do:

			[:triplet |
				(isWorld and: [#(toggleAutoLineLayout toggleIndicateCursor toggleIsPartsBin toggleAlwaysShowThumbnail) includes: triplet second]) ifFalse:
					[aMenu addUpdating: triplet first action: triplet second.
					aMenu balloonTextForLastItem: triplet third translated]]. 

	aMenu addUpdating: #autoViewingString action: #toggleAutomaticViewing.
	aMenu balloonTextForLastItem:  'governs whether, when an object is touched inside me, a viewer should automatically be launched for it.' translated.

	((isWorld not or: [self backgroundSketch notNil]) or: [presenter isNil])
		ifTrue:
			[aMenu addLine].

	isWorld ifFalse:
		[aMenu add: 'set thumbnail height...' translated action: #setThumbnailHeight.
		aMenu balloonTextForLastItem: 'if currently showing thumbnails governs the standard height for them' translated.
		aMenu add: 'behave like a Holder' translated action: #becomeLikeAHolder.
		aMenu balloonTextForLastItem: 'Set properties to make this object nicely set up to hold frames of a scripted animation.' translated].

	self backgroundSketch ifNotNil:
		[aMenu add: 'delete background painting' translated action: #deleteBackgroundPainting.
		aMenu balloonTextForLastItem: 'delete the graphic that forms the background for this me.' translated].
	presenter ifNil:
		[aMenu add: 'make detachable' translated action: #makeDetachable.
		aMenu balloonTextForLastItem: 'Allow this area to be separately governed by its own controls.' translated].

	aMenu addLine.
	aMenu add: 'use standard texture' translated action: #setStandardTexture.
	aMenu balloonTextForLastItem: 'use a pale yellow-and-blue background texture here.' translated.
	aMenu add: 'make graph paper...' translated action: #makeGraphPaper.
	aMenu balloonTextForLastItem: 'Design your own graph paper and use it as the background texture here.' translated.
	aMenu addTitle: 'playfield options...' translated.

	^ aMenu
