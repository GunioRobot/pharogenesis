asStringArray
	^Array streamContents: [ :str |
		str nextPut: 'packages'.
		str nextPut: packages size printString.
		packages do: [ :pack |
			str nextPutAll: pack stringArrayEncoding ]. ].