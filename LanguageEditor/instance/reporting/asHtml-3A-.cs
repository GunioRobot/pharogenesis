asHtml: aString 
	| stream |
	stream := String new writeStream.

	aString
		do: [:each | 
			each caseOf: {
				[Character cr] -> [stream nextPutAll: '<br>'].
				[$&] -> [stream nextPutAll: '&amp;'].
				[$<] -> [stream nextPutAll: '&lt;'].
				[$>] -> [stream nextPutAll: '&gt;'].
				[$*] -> [stream nextPutAll: '&star;'].
				[$@] -> [stream nextPutAll: '&at;']}
				 otherwise: [stream nextPut: each]].

	^ stream contents