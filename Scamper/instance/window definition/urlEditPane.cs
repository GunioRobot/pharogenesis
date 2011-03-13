urlEditPane
	"Create and return the URL edit pane."

	^(PluggableTextMorph on: self text: #currentUrl accept: #jumpToAbsoluteUrl:)
		acceptOnCR: true;
		yourself