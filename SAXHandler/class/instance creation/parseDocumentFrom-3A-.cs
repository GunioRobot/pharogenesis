parseDocumentFrom: aStream
	|  parser |
	parser _ self on: aStream.
	parser startDocument.
	parser parseDocument.
	^parser