paragraph: para bounds: bounds color: c

	| scanner |
	self setPaintColor: c.
	scanner _ port displayScannerFor: para
		foreground: (self shadowColor ifNil:[c]) background: Color transparent
		ignoreColorChanges: self shadowColor notNil.
	para displayOn: self using: scanner at: (bounds topLeft + origin).
