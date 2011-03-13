localeChanged
	#(#ParagraphEditor  )
		do: [:key | Smalltalk
				at: key
				ifPresent: [:class | class initialize]].
	StrikeFont localeChanged.
	Project localeChanged.
	ColorPickerMorph localeChanged.
	Preferences localeChanged