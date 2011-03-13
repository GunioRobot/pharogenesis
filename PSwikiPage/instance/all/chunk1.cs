chunk1
	
	| who |
	^ String streamContents: [:ss | 
		ss nextPutAll: 'self name: '; nextPutAll: name printString;
		nextPutAll: ' date: '''; nextPutAll: date mmddyyyy.
		ss nextPutAll: ''' time: '''.  Time now print24: true on: ss.
		who _ user class == String ifFalse: [address] ifTrue: [user].
		who ifNil: [who _ 'unknown user'].	"must be a string!!"
		ss nextPutAll: ''' by: '; nextPutAll: who printString.
		ss nextPutAll: ' authName: '; nextPutAll: username printString.
		ss nextPutAll: ' authPW: '; nextPutAll: password printString.
		ss nextPutAll: ' privs: '; nextPutAll: privs printString.
		ss nextPutAll: ' text: ']