videoFileShortName
	"answer the receiver's videoFileShortName"
	| fileFull defaultDirFull fileShort |
	mpegFile isNil
		ifTrue: [^ ''].
	" 
	answer the shortest path to the file to make easier to move  
	morphs with references to files between different platforms"
	fileFull := mpegFile fileName.
	""
	defaultDirFull := FileDirectory default fullName.
	fileShort := (fileFull beginsWith: defaultDirFull)
				ifTrue: [fileFull allButFirst: defaultDirFull size + 1]
				ifFalse: [fileFull].
	""
	^ fileShort