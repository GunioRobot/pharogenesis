step
	"NOTE:  The movie player has two modes of play, depending on whether scorePlayer is nil or not.  If scorePlayer is nil, then play runs according to the millisecond clock.  If scorePlayer is not nil, then the scorePlayer is consulted for synchronization.  If the movie is running ahead, then some calls on step will skip their  action until the right time.  If the movie is running behind, then the frame may advance by more than one to maintain synchronization."

	"ALSO: This player operates with overlapped disk i/o.  This means that while one frame is being displayed, the next frame in sequence is being read into a disk buffer.  The value of frameNumber corresponds to the frame currently visible."

	"This code may not work right for playing backwards right now.
	Single-step and backwards (dir <= 0) should just run open-loop."

	|  byteCount simTime ms nextFrameNumber |
	movieFile == nil ifTrue: [^ self].
	scorePlayer == nil
		ifTrue: [(ms _ Time millisecondClockValue) < msAtStart ifTrue:  "clock rollover"
					[msAtStart _ ms - (frameNumber * msPerFrame)].
				simTime _ ms - msAtStart]
		ifFalse: [simTime _ scorePlayer millisecondsSinceStart].
	playDirection > 0
		ifTrue: [nextFrameNumber _ frameAtLastSync + ((simTime - msAtLastSync)//msPerFrame).
				nextFrameNumber = frameNumber ifTrue:
					[((scorePlayer isKindOf: AbstractSound) and: [scorePlayer isPlaying not])
						ifTrue: [^ self stopRunning].
					^ self]]
		ifFalse: [playDirection < 0 ifTrue: [nextFrameNumber _ frameNumber - 1]
								ifFalse: [nextFrameNumber _ frameNumber]].

	byteCount _ self fileByteCountPerFrame.
	movieFile waitForCompletion.
	movieFile primReadResult: movieFile fileHandle
			intoBuffer: currentPage image bits
			at: 1 count: byteCount//4.
	currentPage changed.
	frameNumber _ nextFrameNumber.	

	(playDirection = 0
		or: [(playDirection > 0 and: [frameNumber >= frameCount])
		or: [playDirection < 0 and: [frameNumber <= 1]]])
		ifTrue: [^ self stopRunning].

	"Start the read operation for the next frame..."
	movieFile primReadStart: movieFile fileHandle
			fPosition: (self filePosForFrameNo: frameNumber)
			count: byteCount.
