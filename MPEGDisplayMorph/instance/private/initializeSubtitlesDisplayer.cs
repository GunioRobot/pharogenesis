initializeSubtitlesDisplayer
	"private - builds the subtitle displayer"
	subtitlesDisplayer := MPEGSubtitlesDisplayer on: self selector: #subtitle.
subtitlesDisplayer contents:''.
	self addMorphFront: subtitlesDisplayer.
	^ subtitlesDisplayer