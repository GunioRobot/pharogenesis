nextChar
	sourcePosition := sourcePosition + 1.
	^source at: sourcePosition ifAbsent: [$ ]