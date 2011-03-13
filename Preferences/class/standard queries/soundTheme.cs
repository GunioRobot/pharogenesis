soundTheme
	^ self
		valueOfFlag: #soundTheme
		ifAbsent: [SoundTheme]