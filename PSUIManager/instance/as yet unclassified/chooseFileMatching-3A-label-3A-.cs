chooseFileMatching: patterns label: label
	"Let the user choose a file matching the given patterns"
	
	^UITheme current
		chooseFileNameIn: self modalMorph
		title: (label ifNil: ['Choose File' translated])
		extensions: patterns
		path: nil
		preview: false