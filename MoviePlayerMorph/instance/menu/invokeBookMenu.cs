invokeBookMenu
	"Invoke the book's control panel menu."
	| aMenu sel |
	aMenu _ MVCMenuMorph new.
	aMenu addList:	#(
			('make thumbnail'		thumbnailForThisPage)
			('open movie file'		openMovieFile)
			('add sound track'		addSoundTrack)
		).

	(sel _ aMenu invokeAt: self primaryHand position in: self world)
		ifNotNil: [self perform: sel].
