headerString
	| ps |
	^ String streamContents:
		[:s | s nextPutAll: self knownName.
		2 to: pinSpecs size do:
			[:i | ps _ pinSpecs at: i.
			s nextPutAll: ps pinName , ': ';
				nextPutAll: ps pinName , ' '].
		s cr; tab; nextPutAll: '^ ']