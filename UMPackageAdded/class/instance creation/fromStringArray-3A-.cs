fromStringArray: array
	| str |
	str _ ReadStream on: array.
	str next.
	^self package: (UPackage decodeFromStringStream: str)