paragraph3: para bounds: bounds color: c

	| scanner |
	self setPaintColor: c.
	scanner := (port clippedBy: (bounds translateBy: origin)) displayScannerForMulti: para
		foreground: (self shadowColor ifNil:[c]) background: Color transparent
		ignoreColorChanges: self shadowColor notNil.
	para displayOnTest: (self copyClipRect: bounds) using: scanner at: origin+ bounds topLeft.
