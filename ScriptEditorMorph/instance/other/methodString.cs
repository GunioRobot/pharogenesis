methodString
	^ String streamContents:
		[:aStream |
			aStream nextPutAll: scriptName; cr; cr; tab.
			aStream nextPutAll: self codeString]
