allFileNames
	| index |
	index _ HTTPSocket httpGet: self locationWithTrailingSlash, '?C=M;O=D' args: nil user: user passwd: password.
	index isString ifTrue: [self error: 'Could not access ', location].
	^ self parseFileNamesFromStream: index	