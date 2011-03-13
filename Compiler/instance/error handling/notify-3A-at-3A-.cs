notify: aString at: location
	"Refer to the comment in Object|notify:."

	requestor == nil
		ifTrue: [^SyntaxErrorNotification
					inClass: class
					category: category
					withCode: 
						(sourceStream contents
							copyReplaceFrom: location
							to: location - 1
							with: aString)
					doitFlag: false]
		ifFalse: [^requestor
					notify: aString
					at: location
					in: sourceStream]