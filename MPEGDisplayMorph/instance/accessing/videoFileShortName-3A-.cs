videoFileShortName: aString 
	"change the receiver's videoFileShortName, that means open 
	the video file named aString"
	| fullName |
	self stopPlaying.
	fullName := FileDirectory default fullNameFor: aString.
	self openFileNamed: fullName