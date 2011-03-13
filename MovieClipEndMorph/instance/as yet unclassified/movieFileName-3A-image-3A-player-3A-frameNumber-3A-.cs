movieFileName: movieFileName image: aForm player: aMoviePlayer frameNumber: n

	movieClipFileName := movieFileName.
	self image: aForm frameNumber: n.
	moviePlayerMorph := movieClipPlayer := aMoviePlayer.
	scoreEvent := AmbientEvent new morph: self.
