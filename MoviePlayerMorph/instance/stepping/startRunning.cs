startRunning
	| ms |
	(frameBufferIfScaled ifNil: [currentPage image]) unhibernate.
	movieFile := AsyncFile new 
				open: (FileDirectory default fullNameFor: movieFileName)
				forWrite: false.
	movieFile 
		primReadStart: movieFile fileHandle
		fPosition: (self filePosForFrameNo: frameNumber)
		count: self fileByteCountPerFrame.
	scorePlayer isNil 
		ifTrue: 
			[ms := Time millisecondClockValue.
			msAtStart := ms - ((frameNumber - 1) * msPerFrame).
			msAtLastSync := ms - msAtStart]
		ifFalse: 
			[(playDirection > 0 and: [scorePlayer isKindOf: SampledSound]) 
				ifTrue: 
					[scorePlayer
						reset;
						playSilentlyUntil: (frameNumber - 1) * msPerFrame / 1000.0;
						initialVolume: 1.0.
					
					[scorePlayer resumePlaying.
					msAtLastSync := scorePlayer millisecondsSinceStart] 
							forkAt: Processor userInterruptPriority].
			msAtLastSync := scorePlayer millisecondsSinceStart].
	frameAtLastSync := frameNumber