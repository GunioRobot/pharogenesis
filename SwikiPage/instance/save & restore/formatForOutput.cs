formatForOutput
	^ String streamContents: [:ss |
		ss nextPutAll: 'self '.
		self outputFormat do: [:block |
							ss nextPutAll:
(block value: self)
					"ifError: [:msg :rec |
							 ss nextPutAll:
'*** ', rec asString, ': ', msg
asString ]"].
		ss nextPutAll: 'text: '].

"		   nextPutAll: name printString;
		   nextPutAll: ' date: ''';
		   nextPutAll: date mmddyyyy.
		ss nextPutAll: ''' time: '''.
		     Time now print24: true on: ss.
		who _ user class == String
					ifFalse: [address]
					ifTrue: [user].
		who ifNil: [who _ 'unknown user'].
		ss nextPutAll: ''' by: ';
		   nextPutAll: who printString.
		ss nextPutAll: ' text: ']"