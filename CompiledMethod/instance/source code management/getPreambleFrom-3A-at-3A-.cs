getPreambleFrom: aFileStream at: position
	|  writeStream |
	writeStream _ String new writeStream.
	position
		to: 0
		by: -1
		do: [:p | 
			| c | 
			aFileStream position: p.
			c _ aFileStream basicNext.
			c == $!
				ifTrue: [^ writeStream contents reverse]
				ifFalse: [writeStream nextPut: c]]