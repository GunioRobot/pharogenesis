chunk1
	^self formatForOutput
	"| who |
	^ String streamContents: [:ss |
		ss nextPutAll: 'self name: '; nextPutAll: name printString;
		nextPutAll: ' date: '''; nextPutAll: date mmddyyyy.
		ss nextPutAll: ''' time: '''.  time print24: true on: ss.
		who _ user class == String ifFalse: [address] ifTrue: [user].
		who ifNil: [who _ 'unknown user'].
		ss nextPutAll: ''' by: '; nextPutAll: who printString.
		ss nextPutAll: ' text: ']"