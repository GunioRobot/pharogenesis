fromStringArray: array
	| str packages numPackages |
	str _ ReadStream on: array.
	str next.  "skip the 'packages' designation".

	packages _ OrderedCollection new.

	numPackages _ Integer readFromString: str next.
	numPackages timesRepeat: [
		packages add: (UPackage decodeFromStringStream: str) ].
		
	^self packages: packages