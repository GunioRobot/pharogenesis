splitAtCapsAndDownshifted: aString

	self flag: #yoCharCases.

	^String streamContents: [ :strm |
		aString do: [ :each | 
			each = $: ifFalse: [
				each isUppercase ifTrue: [strm nextPut: (Character value: 0);  
						 	nextPut: (Character value: 0); 
						 	nextPut: (Character value: 0); 
							nextPut: each asLowercase]
					ifFalse: [strm nextPut: each]
			].
		]
	].