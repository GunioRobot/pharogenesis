notify: string at: location
	requestor isNil
		ifTrue: [(encoder == self or: [encoder isNil]) ifTrue: [^ self fail  "failure setting up syntax error"].
				SyntaxErrorNotification
					inClass: encoder classEncoding
					withCode: 
						(source contents
							copyReplaceFrom: location
							to: location - 1
							with: string , ' ->')
					doitFlag: doitFlag]
		ifFalse: [requestor
					notify: string , ' ->'
					at: location
					in: source].
	^self fail