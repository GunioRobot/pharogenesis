totalSeconds
	"Answer the total number of seconds in this movie."

	mpegFile ifNil: [^ 0].
	mpegFile fileHandle ifNil: [^ 0].
	(FileStream isAFileNamed: mpegFile fileName) ifFalse: [^ 0].
	mpegFile hasVideo ifFalse: [^ 0].
	^ self totalFrames asFloat / (mpegFile videoFrameRate: 0)