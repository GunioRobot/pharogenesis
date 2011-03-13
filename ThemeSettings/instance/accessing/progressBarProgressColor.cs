progressBarProgressColor
	"Answer the value of progressBarProgressColor"

	^progressBarProgressColor ifNil: [Preferences menuTitleColor]