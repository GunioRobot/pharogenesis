subtitlesDisplayer
	"private - answer the receiver's subtitlesDisplayer. create one  
	if needed"
	^ subtitlesDisplayer
		ifNil: [self initializeSubtitlesDisplayer]