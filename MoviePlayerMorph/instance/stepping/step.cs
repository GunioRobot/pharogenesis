step
	"NOTE:  The movie player has two modes of play, depending on whether scorePlayer is nil or not.  If scorePlayer is nil, then play runs according to the millisecond clock.  If scorePlayer is not nil, then the scorePlayer is consulted for synchronization.  If the movie is running ahead, then some calls on step will skip their  action until the right time.  If the movie is running behind, then the frame may advance by more than one to maintain synchronization."

	"ALSO: This player operates with overlapped disk i/o.  This means that while one frame is being displayed, the next frame in sequence is being read into a disk buffer.  The value of frameNumber corresponds to the frame currently visible."

	"This code may not work right for playing backwards right now.
	Single-step and backwards (dir <= 0) should just run open-loop."

	| byteCount simTime ms nextFrameNumber |
	movieFile isNil ifTrue: [^self].
	scorePlayer isNil 
		ifTrue: 
			[(ms := Time millisecondClockValue) < msAtStart 
				ifTrue: 
					["clock rollover"

					msAtStart := ms - (frameNumber * msPerFrame)].
			simTime := ms - msAtStart]
		ifFalse: [simTime := scorePlayer millisecondsSinceStart].
	playDirection > 0 
		ifTrue: 
			[nextFrameNumber := frameAtLastSync 
						+ ((simTime - msAtLastSync) // msPerFrame).
			nextFrameNumber = frameNumber 
				ifTrue: 
					[((scorePlayer isKindOf: AbstractSound) and: [scorePlayer isPlaying not]) 
						ifTrue: [^self stopRunning].
					^self]]
		ifFalse: 
			[nextFrameNumber := playDirection < 0 
						ifTrue: [frameNumber - 1]
						ifFalse: [frameNumber]].
	byteCount := self fileByteCountPerFrame.
	self stepSoundTrack.
	movieFile waitForCompletion.
	movieFile 
		primReadResult: movieFile fileHandle
		intoBuffer: (frameBufferIfScaled ifNil: [currentPage image]) bits
		at: 1
		count: byteCount // 4.
	frameBufferIfScaled ifNotNil: 
			["If this player has been shrunk, then we have to warp to the current page."

			(WarpBlt current toForm: currentPage image)
				sourceForm: frameBufferIfScaled;
				combinationRule: 3;
				cellSize: (playDirection = 0 
							ifTrue: 
								["Use smoothing if just stepping"

								2]
							ifFalse: [1]);
				copyQuad: frameBufferIfScaled boundingBox innerCorners
					toRect: currentPage image boundingBox].
	currentPage changed.
	frameNumber := nextFrameNumber.
	(playDirection = 0 or: 
			[(playDirection > 0 and: [frameNumber >= frameCount]) 
				or: [playDirection < 0 and: [frameNumber <= 1]]]) 
		ifTrue: [^self stopRunning].

	"Start the read operation for the next frame..."
	movieFile 
		primReadStart: movieFile fileHandle
		fPosition: (self filePosForFrameNo: frameNumber)
		count: byteCount