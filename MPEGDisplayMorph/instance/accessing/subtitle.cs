subtitle
	"answer the subtitle for the current frame"
	self hasSubtitles
		ifFalse: [^ ''].
	self mpegFileIsOpen
		ifFalse: [^ ''].
	mpegFile hasVideo
		ifFalse:[^''].
""
^ subtitles
				subtitleForFrame: (mpegFile videoGetFrame: 0)