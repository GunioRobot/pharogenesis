createJPEGfromSqueakMovie
	"Create a new JPEG movie file from an SqueakTime movie. Prompt the user for the file names and the quality setting, then do the conversion."

	| result squeakMovieFileName jpegFileName q |
	result := StandardFileMenu oldFile.
	result ifNil: [^self].
	squeakMovieFileName := result directory pathName , FileDirectory slash 
				, result name.
	jpegFileName := FillInTheBlank request: 'New movie name?' translated.
	jpegFileName isEmpty ifTrue: [^self].
	(jpegFileName asLowercase endsWith: '.jmv') 
		ifFalse: [jpegFileName := jpegFileName , '.jmv'].
	result := FillInTheBlank request: 'Quality level (1 to 100)?' translated.
	q := result ifNil: [50]
				ifNotNil: [(result asNumber rounded max: 1) min: 100].
	JPEGMovieFile 
		convertSqueakMovieNamed: squeakMovieFileName
		toJPEGMovieNamed: jpegFileName
		quality: q