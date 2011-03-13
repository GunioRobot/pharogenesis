embeddedInMorphicWindowLabeled: labelString wrap: aBoolean
	| window |
	window :=  (SystemWindow labelled: labelString) model: self.
	window addMorph: ((PluggableTextMorph 
		on: self 
		text: #contents 
		accept: #acceptContents:
		readSelection: nil 
		menu: #codePaneMenu:shifted:)
			wrapFlag: aBoolean)
				frame: (0@0 corner: 1@1).
	^ window