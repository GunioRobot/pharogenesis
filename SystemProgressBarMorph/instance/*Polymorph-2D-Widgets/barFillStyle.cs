barFillStyle
	"Answer the fillStyle for the bar if present or
	Preferences menuTitleColor otherwise."

	^self valueOfProperty: #barFillStyle ifAbsent: [Preferences menuTitleColor]