thumbnailForThisPage
	"Overridden to make a MovieFrameSyncMorph"
	| image |
	image _ currentPage image.
	self activeHand attachMorph:
		(MovieFrameSyncMorph new
			image: (image magnifyBy: 50 asFloat / (image width max: image height))
			player: self frameNumber: frameNumber)
