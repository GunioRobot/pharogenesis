readStreamForFileNamed: aString do: aBlock
	| contents |
	contents _ HTTPSocket httpGet: (self urlForFileNamed: aString) args: nil user: user passwd: password.
	^ contents isString ifFalse: [aBlock value: contents]