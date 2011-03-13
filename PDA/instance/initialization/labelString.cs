labelString

	| today |
	today _ Date today.
	^ String streamContents:
		[:s | s nextPutAll: today weekday; space.
		Time now print24: false showSeconds: false on: s.
		s nextPutAll: '  --  '.
		s nextPutAll: today monthName; space; print: today dayOfMonth;
			nextPutAll: ', '; print: today year]