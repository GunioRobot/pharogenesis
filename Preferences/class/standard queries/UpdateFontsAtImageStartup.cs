UpdateFontsAtImageStartup
	^ self
		valueOfFlag: #UpdateFontsAtImageStartup
		ifAbsent: [false]