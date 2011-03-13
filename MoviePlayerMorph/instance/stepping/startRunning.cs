startRunning

	| ms |
	(frameBufferIfScaled ifNil: [currentPage image]) unhibernate.
	movieFile _ AsyncFile new open: movieFileName forWrite: false.
	movieFile primReadStart: movieFile fileHandle
			fPosition: (self filePosForFrameNo: frameNumber)
			count: self fileByteCountPerFrame.
	scorePlayer == nil
		ifTrue: [ms _ Time millisecondClockValue.
				msAtStart _ ms - ((frameNumber-1) * msPerFrame).
				msAtLastSync _ ms - msAtStart.
				frameAtLastSync _ frameNumber]
		ifFalse: [(playDirection > 0 and: [scorePlayer isKindOf: SampledSound]) ifTrue:
					[scorePlayer reset;
							playSilentlyUntil: (frameNumber - 1 * msPerFrame / 1000.0);						initialVolume: 1.0.
					[scorePlayer resumePlaying.
					msAtLastSync _ scorePlayer millisecondsSinceStart]
						forkAt: Processor userInterruptPriority].
				msAtLastSync _ scorePlayer millisecondsSinceStart.
				frameAtLastSync _ frameNumber]