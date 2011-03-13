chooseColor: aColor title: label
	"Answer the user choice of a colour."
	
	^UITheme current
		chooseColorIn: self modalMorph
		title: (label ifNil: ['Choose Color' translated])
		color: aColor