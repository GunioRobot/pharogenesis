allFileNames
	| index |
	index := HTTPSocket httpGet: self locationWithTrailingSlash, '?C=M;O=D' args: nil user: self user passwd: self password.
	index isString ifTrue: [self error: 'Could not access ', location].
	^ self parseFileNamesFromStream: index	