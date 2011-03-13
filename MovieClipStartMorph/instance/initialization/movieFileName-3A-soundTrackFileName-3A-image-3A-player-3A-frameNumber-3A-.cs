movieFileName: movieFileName soundTrackFileName: soundFileName
			image: aForm player: aMoviePlayer frameNumber: n
	movieClipFileName := movieFileName.
	soundTrackFileName := soundFileName.
	self image: aForm frameNumber: n.
	moviePlayerMorph := aMoviePlayer.
	soundTrackPlayerReady := moviePlayerMorph scorePlayer copy.
	scoreEvent := AmbientEvent new morph: self.
