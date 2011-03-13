makeThumbnailInHand: aHand

	scorePlayer ifNotNil:
		["Position the soundTrack for this frameNumber"
		scorePlayer reset; playSilentlyUntil: frameNumber - 1 * msPerFrame / 1000.0].

	aHand attachMorph:
		(MovieClipStartMorph new
			movieFileName: movieFileName
			soundTrackFileName: soundTrackFileName
			image: currentPage image
			player: self
			frameNumber: frameNumber)
