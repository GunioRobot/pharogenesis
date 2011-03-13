addPanesTo: window from: aCollection

	aCollection do: [ :each |
		window addMorph: each first frame: each second.
	]