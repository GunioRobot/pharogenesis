subtitlesFileShortName
	"answer the receiver's subtitlesFileShortName"
	| fileFull defaultDirFull fileShort |
	self hasSubtitles ifFalse:[^ ''].
	" 
	answer the shortest path to the file to make easier to move  
	morphs with references to files between different platforms"
	fileFull := subtitles fileName.
	""
	defaultDirFull := FileDirectory default fullName.
	fileShort := (fileFull beginsWith: defaultDirFull)
				ifTrue: [fileFull allButFirst: defaultDirFull size + 1]
				ifFalse: [fileFull].
	""
	^ fileShort