text: s bounds: boundsRect font: fontOrNil color: c
	| scanner |
	scanner _ DisplayScanner quickPrintOn: form
				box: ((boundsRect translateBy: origin) intersect: clipRect) truncated
				font: fontOrNil
				color: (self shadowColor ifNil:[c]).
	scanner drawString: s at: boundsRect topLeft + origin