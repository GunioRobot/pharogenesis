moviePosition
	"Answer a number between 0.0 and 1.0 indicating the current position within the movie."

	mpegFile ifNil: [^ 0.0].
	mpegFile fileHandle ifNil: [^ 0.0].
	(FileStream isAFileNamed: mpegFile fileName) ifFalse: [^0.0].
	mpegFile hasVideo
		ifTrue: [^ ((mpegFile videoGetFrame: 0) asFloat / (mpegFile videoFrames: 0)) min: 1.0].
	soundTrack ifNotNil: [^ soundTrack soundPosition].
	^ 0.0
