scannerError
	(stream atEnd and: [start == (stream position + 1)]) 
		ifTrue: 
			[returnMatchBlock value: (SmaCCToken 
						value: ''
						start: start
						id: (Array with: self emptySymbolTokenId))].
	stream position: start - 1.
	returnMatchBlock value: (SmaCCToken 
				value: (String with: stream next)
				start: start
				id: #(0))