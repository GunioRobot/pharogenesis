progressBarColor
	"Answer the value of progressBarColor"

	^progressBarColor ifNil: [Preferences menuColor muchLighter]