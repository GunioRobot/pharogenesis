embeddedInMorphicWindowLabeled: labelString
	| window pane |
	window _ (SystemWindow labelled: labelString) model: self.
	pane := PluggableTextMorph on: self text: #contents accept: #acceptContents:
			readSelection: nil menu: #codePaneMenu:shifted:.
	pane  font: Preferences standardCodeFont.
	window addMorph: pane frame: (0@0 corner: 1@1).
	^ window