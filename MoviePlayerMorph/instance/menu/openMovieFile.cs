openMovieFile
	| fileName |
	fileName := Utilities chooseFileWithSuffixFromList: #('.movie')
					withCaption: 'Choose a movie file to open'.
	fileName ifNotNil:
		[self openFileNamed: fileName.
		self showMoreControls]