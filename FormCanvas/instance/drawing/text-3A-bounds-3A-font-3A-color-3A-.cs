text: s bounds: boundsRect font: fontOrNil color: c
	| scanner |
	scanner _ QuickPrint newOn: form
				box: ((boundsRect translateBy: origin) intersect: clipRect) truncated
				font: fontOrNil
				color: (shadowDrawing ifTrue: [shadowStipple] ifFalse: [c]).
	scanner drawString: s at: boundsRect topLeft + origin