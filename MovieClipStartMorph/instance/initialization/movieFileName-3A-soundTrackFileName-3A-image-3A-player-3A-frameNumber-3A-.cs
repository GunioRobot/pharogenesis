movieFileName: movieFileName soundTrackFileName: soundFileName
			image: aForm player: aMoviePlayer frameNumber: n
	movieClipFileName _ movieFileName.
	soundTrackFileName _ soundFileName.
	self image: aForm frameNumber: n.
	moviePlayerMorph _ aMoviePlayer.
	soundTrackPlayerReady _ moviePlayerMorph scorePlayer copy.
	scoreEvent _ AmbientEvent new morph: self.
