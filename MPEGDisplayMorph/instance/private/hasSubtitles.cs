hasSubtitles
	"answer if the receiver has subtitles or not"
	^ mpegFile isNil not
		and: [subtitles isNil not]