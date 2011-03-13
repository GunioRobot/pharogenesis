findRealFont
	"for now just get a strike"
	"^((TextStyle named: 'Accuny') fontOfPointSize: pointSize)
		emphasized: emphasis"
	^LogicalFontManager current bestFontFor: self