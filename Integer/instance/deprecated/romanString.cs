romanString	"1999 romanString"
	self deprecated: 'Use ', self printString, ' printStringRoman instead!'.
	[self > 0] assert.
	^ String streamContents:
		[:s |
		self // 1000 timesRepeat: [s nextPut: $M].
		self romanDigits: 'MDC' for: 100 on: s.
		self romanDigits: 'CLX' for: 10 on: s.
		self romanDigits: 'XVI' for: 1 on: s]