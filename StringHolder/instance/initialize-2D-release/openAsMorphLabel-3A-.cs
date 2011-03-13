openAsMorphLabel: labelString 
	"Workspace new openAsMorphLabel: 'Workspace'"
	| window |
	window _ (SystemWindow labelled: labelString) model: self.

	window addMorph: (PluggableTextMorph on: self text: #contents accept: #acceptContents:
			readSelection: nil menu: nil)
		frame: (0@0 corner: 1@1).

	window openInWorld