invokeBookMenu
	"Invoke the book's control panel menu."
	| aMenu |
	aMenu _ MVCMenuMorph new defaultTarget: self.
	aMenu add:	'make a new movie' action: #makeAMovie.
	aMenu add:	'open movie file' action: #openMovieFile.
	aMenu add:	'add sound track' action: #addSoundTrack.
	aMenu addLine.
	scorePlayer ifNotNil:
		[soundTrackForm == nil
			ifTrue: [aMenu add:	'show sound track' action: #showHideSoundTrack]
			ifFalse: [aMenu add:	'hide sound track' action: #showHideSoundTrack]].
	aMenu add:	'make thumbnail' action: #thumbnailForThisPage.
	cueMorph ifNotNil:
		["Should check if piano roll and score already have a start event
		prior to this time."
		aMenu add:	'end clip here' action: #endClipHere].

	aMenu popUpEvent: self world activeHand lastEvent in: self world
