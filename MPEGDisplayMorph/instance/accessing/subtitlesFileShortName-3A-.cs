subtitlesFileShortName: aString 
	"change the receiver's subtitlesFileShortName, that means 
	open the subtitles file named aString"
	| fullName |
	self mpegFileIsOpen
		ifFalse: [^ self].
	mpegFile hasVideo
		ifFalse: [^ self].
	""
	fullName := FileDirectory default fullNameFor: aString.
	self openSubtitlesFileNamed: fullName