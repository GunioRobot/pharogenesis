playFile: aFileName
	"Play the given file (if not nil) in an MPEGMoviePlayerMorph"

     | wrapper |
	aFileName ifNil: [^ Beeper beep].
     wrapper _ self openOn: aFileName.
     wrapper moviePlayer startPlaying. 
     "wrapper openInWindow."
	wrapper openInWorld.
     ^wrapper