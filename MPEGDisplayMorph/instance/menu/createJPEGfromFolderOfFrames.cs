createJPEGfromFolderOfFrames
	"Create a new JPEG movie file from an folder of individual frames. Prompt the user for the folder and file names and the quality setting, then do the conversion."

	| result folderName jpegFileName q frameRate |
	result := StandardFileMenu oldFile.
	result ifNil: [^self].
	folderName := result directory pathName.
	jpegFileName := FillInTheBlank request: 'New movie name?' translated.
	jpegFileName isEmpty ifTrue: [^self].
	(jpegFileName asLowercase endsWith: '.jmv') 
		ifFalse: [jpegFileName := jpegFileName , '.jmv'].
	result := FillInTheBlank request: 'Quality level (1 to 100)?' translated.
	q := result ifNil: [50]
				ifNotNil: [(result asNumber rounded max: 1) min: 100].
	result := FillInTheBlank request: 'Frame rate?' translated.
	frameRate := result ifNil: [10]
				ifNotNil: [(result asNumber rounded max: 1) min: 100].
	JPEGMovieFile 
		convertFromFolderOfFramesNamed: folderName
		toJPEGMovieNamed: jpegFileName
		frameRate: frameRate
		quality: q