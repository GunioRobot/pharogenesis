buildPassFailText
	passFailText _ PluggableTextMorph
				on: self
				text: #passFail
				accept: nil.
	passFailText hideScrollBarsIndefinitely.
	^ passFailText