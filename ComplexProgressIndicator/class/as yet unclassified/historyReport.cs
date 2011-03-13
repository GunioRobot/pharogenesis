historyReport
"
ComplexProgressIndicator historyReport
"
	| answer data |
	History ifNil: [^1 beep].
	answer _ String streamContents: [ :strm |
		(History keys asSortedCollection: [ :a :b | a asString <= b asString]) do: [ :k |
			strm nextPutAll: k printString; cr.
			data _ History at: k.
			(data keys asSortedCollection: [ :a :b | a asString <= b asString]) do: [ :dataKey |
				strm tab; nextPutAll: dataKey printString,'  ',
					(data at: dataKey) asArray printString; cr.
			].
			strm cr.
		].
	].
	StringHolder new
		contents: answer contents;
		openLabel: 'Progress History'