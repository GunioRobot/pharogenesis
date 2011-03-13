notify: string at: location
	requestor isNil
		ifTrue: [SyntaxError 
					errorInClass: encoder classEncoding
					withCode: 
						(source contents
							copyReplaceFrom: location
							to: location - 1
							with: string , ' ->')]
		ifFalse: [requestor
					notify: string , ' ->'
					at: location
					in: source].
	^self fail
