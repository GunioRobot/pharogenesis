parameterAt: aKey default: defaultValueBlock
	"Return the Parameter setting at the given key.  If there is no entry for this key in the Parameters dictionary, create one with the value of defaultValueBlock as its value"

	^ Parameters at: aKey ifAbsent: [Parameters at: aKey put: defaultValueBlock value]