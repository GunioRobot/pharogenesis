initialize  "PopUpMenu initialize"
	(MenuStyle _ TextStyle default copy)
		gridForFont: TextStyle default defaultFontIndex withLead: 0;
		centered.
	PopUpMenu allSubInstancesDo: [:m | m rescan]