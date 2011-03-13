localeChanged
	#(#ParagraphEditor #BitEditor #FormEditor #StandardSystemController )
		do: [:key | Smalltalk
				at: key
				ifPresent: [:class | class initialize]].
	StrikeFont localeChanged.
	PartsBin localeChanged.
	Project localeChanged.
	PaintBoxMorph localeChanged.
	ColorPickerMorph localeChanged.
	Preferences localeChanged