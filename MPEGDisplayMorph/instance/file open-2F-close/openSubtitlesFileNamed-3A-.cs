openSubtitlesFileNamed: aString 
	"Try to open the subtitle file with the given name. Answer true  
	if successful."
	subtitles := nil.
	""
	"try to create the displayer.  it's useful for instances of mpegplayer older than the subtitles support"
	self subtitlesDisplayer.
	""
	(FileDirectory default fileExists: aString)
		ifFalse: [self
				inform: ('File not found: {1}' translated format: {aString}).
			^ false].
	Utilities
		informUser: 'opening the file, please wait' translated
		during: [subtitles := MPEGSubtitles fromFileNamed: aString]