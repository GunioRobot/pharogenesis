parseByteValue
	"skip over separators and return next bytevalue parsed as a C language number:
		0ddd is an octal digit.
		0xddd is a hex digit.
		ddd is decimal."
	| source mybase |
	stream skipSeparators.
	source _ ReadWriteStream on: String new.
	[stream atEnd or: [ stream peek isSeparator ]]
		whileFalse: [source nextPut: self next asUppercase].
	mybase _ 10. "Base 10 default"
	source reset.
	(source peek = $0) ifTrue: [
		mybase _ 8. "Octal or Hex, say its Octal unless overridden."
		source next.
		(source peek = $X) ifTrue: [
			mybase _ 16. "Ah.  It's Hex."
			source next.
			]
		].
	^ Integer readFrom: source base: mybase