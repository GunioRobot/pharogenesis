fromStringArray: array
	^self username: array second password: array third package: (UPackage decodeFromStringStream: (ReadStream on: (array allButFirst: 3)))