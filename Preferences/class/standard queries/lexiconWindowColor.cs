lexiconWindowColor
	^ self
		valueOfFlag: #lexiconWindowColor
		ifAbsent: [Color
				r: 0.878
				g: 1.0
				b: 0.878]