invokeBookMenu
	"Invoke the book's control panel menu."
	| aMenu |
	aMenu _ MVCMenuMorph new defaultTarget: self.
	aMenu add:	'make a new movie' translated action: #makeAMovie.
	aMenu add:	'open movie file' translated action: #openMovieFile.
	aMenu add:	'add sound track' translated action: #addSoundTrack.
	aMenu addLine.
	scorePlayer ifNotNil:
		[soundTrackForm isNil
			ifTrue: [aMenu add:	'show sound track' translated action: #showHideSoundTrack]
			ifFalse: [aMenu add:	'hide sound track' translated action: #showHideSoundTrack]].
	aMenu add:	'make thumbnail' translated action: #thumbnailForThisPage.
	cueMorph ifNotNil:
		["Should check if piano roll and score already have a start event
		prior to this time."
		aMenu add:	'end clip here' translated action: #endClipHere].

	aMenu popUpEvent: self world activeHand lastEvent in: self world
