httpGet: url
	| document |
	document _ self httpGetDocument: url.
	^(document isString)
		ifTrue: [
			"strings indicate errors"
			document]
		ifFalse: [(RWBinaryOrTextStream with: document content) reset]