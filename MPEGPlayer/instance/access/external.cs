external
	[external hasVideo] on: Error do: 
		[self isBuffer
			ifTrue:
			[external := MPEGFile openBuffer: external buffer]
			ifFalse: 
				[(MPEGFile isFileValidMPEG: external fileName) 
					ifFalse: [^self error: 'Mpeg File is invalid'].
				external := MPEGFile openFile: external fileName]].
	^external