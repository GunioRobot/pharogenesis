install: stream usingBasename: basename
	| movieDir movieFile |
	movieDir := FileDirectory default directoryNamed: 'movies'.
	movieDir assureExistence.
	
	movieDir removeFileNamed: basename.
	
	movieFile _ movieDir newFileNamed: basename, '.mpeg'.
	stream binary.  movieFile binary.
	movieFile nextPutAll: stream upToEnd.
	movieFile close.
	
	Smalltalk at: #MPEGMoviePlayerMorph ifPresent: [ :player |
		player playFile: (movieDir fullNameFor: basename, '.mpeg') ]