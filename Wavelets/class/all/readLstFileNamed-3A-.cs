readLstFileNamed: fName     "Wavelets readLstFilenamed: 'Lori.lst'"
	| samples sign f |
	f _ FileStream readOnlyFileNamed: fName.
	samples _ OrderedCollection new.
	[f atEnd]
		whileFalse:
		[f skipSeparators.
		sign _ (f peekFor: $-) ifTrue: [-1.0] ifFalse: [1.0].
		samples addLast: (Number readFrom: (f upTo: $,)) * sign].
	^ samples asArray
"
((self collect: [:x | (x * 128.0) rounded + 128]) as: ByteArray) fullPrintString
"