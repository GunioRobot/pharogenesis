forFileName: aString

	| path |
	path _ self dirPathFor: aString.
	path isEmpty ifTrue: [^ self default].
	^ self on: path
