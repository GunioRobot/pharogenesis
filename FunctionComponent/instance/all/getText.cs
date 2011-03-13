getText
	| ps |
	^ ('"type a function of' ,
		(String streamContents:
			[:s | 2 to: pinSpecs size do:
				[:i | ps _ pinSpecs at: i.
				(i>2 and: [i = pinSpecs size]) ifTrue: [s nextPutAll: ' and'].
				s nextPutAll: ' ', ps pinName]]) ,
		'"') asText