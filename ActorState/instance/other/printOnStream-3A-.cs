printOnStream: aStream
	aStream print: 'ActorState for '; print:owningPlayer externalName; print:' '.
	penDown ifNotNil: [aStream cr; print: 'penDown '; write:penDown].
	penColor ifNotNil: [aStream cr; print: 'penColor '; write:penColor].
	penSize ifNotNil: [aStream cr; print: 'penSize '; write:penSize].
	instantiatedUserScriptsDictionary ifNotNil:
		[aStream cr; print:
			'+ '; write: instantiatedUserScriptsDictionary size; print:' user scripts'].
