openMovieFile
	| fileName |
	fileName _ Utilities chooseFileWithSuffixFromList: #('.movie')
					withCaption: 'Choose a movie file to open'.
	fileName ifNotNil:
		[self openFileNamed: fileName.
		self showMoreControls]