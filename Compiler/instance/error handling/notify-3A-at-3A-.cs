notify: aString at: location
	"Refer to the comment in Object|notify:."

	requestor == nil
		ifTrue: [^SyntaxError 
					errorInClass: class
					withCode: 
						(sourceStream contents
							copyReplaceFrom: location
							to: location - 1
							with: aString)]
		ifFalse: [^requestor
					notify: aString
					at: location
					in: sourceStream]