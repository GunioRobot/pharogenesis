unreferencedKeys		"TextConstants unreferencedKeys"
	| n |
	^ 'Scanning for references . . .'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: self size
		during:
		[:bar | n _ 0.
		self keys select:
			[:key | bar value: (n _ n+1).
			(Smalltalk allCallsOn: (self associationAt: key)) isEmpty]]