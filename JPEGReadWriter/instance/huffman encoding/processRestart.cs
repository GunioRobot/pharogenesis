processRestart

	bitBuffer _ 0.
	bitsInBuffer _ 0.
	self parseNextMarker.
	currentComponents do: [:c | c priorDCValue: 0].
	restartsToGo _ restartInterval.