splitNameVersionExtensionFor: fileName
	" answer an array with the root name, version # and extension.
	See comment in nextSequentialNameFor: for more details"

	| baseName version extension i j |

	baseName _ self class baseNameFor: fileName.
	extension _ self class extensionFor: fileName.
	i _ j _ baseName findLast: [:c | c isDigit not].
	i = 0
		ifTrue: [version _ 0]
		ifFalse:
			[(baseName at: i) = $.
				ifTrue:
					[version _ (baseName copyFrom: i+1 to: baseName size) asNumber.
					j _ j - 1]
				ifFalse: [version _ 0].
			baseName _ baseName copyFrom: 1 to: j].
	^ Array with: baseName with: version with: extension