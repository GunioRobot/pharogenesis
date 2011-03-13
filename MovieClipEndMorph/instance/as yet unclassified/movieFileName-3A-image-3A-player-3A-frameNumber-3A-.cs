movieFileName: movieFileName image: aForm player: aMoviePlayer frameNumber: n

	movieClipFileName _ movieFileName.
	self image: aForm frameNumber: n.
	moviePlayerMorph _ movieClipPlayer _ aMoviePlayer.
	scoreEvent _ AmbientEvent new morph: self.
