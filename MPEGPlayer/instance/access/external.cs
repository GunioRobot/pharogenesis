external
	[external hasVideo] on: Error do: 
		[(MPEGFile isFileValidMPEG: external fileName) 
			ifFalse: [^self error: 'Mpeg File is invalid'].
		external _ MPEGFile openFile: external fileName].
	^external