openAsMorphLabel: labelString 
	"Build a morph viewing this transcriptStream"
	| window |
	window _ (SystemWindow labelled: labelString) model: self.
	window addMorph: (PluggableTextMorph on: self text: nil accept: nil
			readSelection: nil menu: #codePaneMenu:shifted:)
		frame: (0@0 corner: 1@1).
	^ window