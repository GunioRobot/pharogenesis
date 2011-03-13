privateFullPathForURI: aURI
	| path |
	path := aURI path.

	"Check for drive notation (a: etc)"
	path size > 1
		ifTrue: [
			((path at: 3) = $:)
				ifTrue: [path := path copyFrom: 2 to: path size]
				ifFalse: [
					"All other cases should be network path names (\\xxx\sdsd etc)"
					path := '/' , path]].

	^(path copyReplaceAll: '/' with: self slash) unescapePercents