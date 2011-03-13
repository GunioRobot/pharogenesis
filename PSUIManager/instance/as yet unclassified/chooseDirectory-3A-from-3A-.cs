chooseDirectory: label from: dir
	"Answer the user choice of a directory."
	
	^UITheme current
		chooseDirectoryIn: self modalMorph
		title: (label ifNil: ['Choose Directory' translated])
		path: (dir ifNotNil: [dir pathName])