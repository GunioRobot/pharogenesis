openSubtitlesFile
	"Invoked by the 'Subtitles' button. Prompt for a file name and 
	try to open that file as a subs file."
	| result |
	self mpegFileIsOpen
		ifFalse: [^ self].
	mpegFile hasVideo
		ifFalse: [self inform: 'select a video file' translated.
			^ self].
	result := FileList2 modalFileSelectorForSuffixes: #('sub' ).
	result
		ifNil: [^ self].
	self openSubtitlesFileNamed: result fullName