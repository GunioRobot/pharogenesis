replaceFrom: start to: stop with: replacement startingAt: repStart
	| max |
	max _ (replacement size - repStart) min: stop-start.
	start to: start+max do:[:i|
		self at: i put: (replacement at: i - start + repStart).
	].