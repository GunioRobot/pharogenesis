select: buttonname values: values selections: selections size: size multiple: multiple 
	| stream |
	stream _ WriteStream on: ''.
	stream nextPutAll: '<SELECT NAME="' , buttonname , '"' , (multiple
				ifTrue: [' MULTIPLE']
				ifFalse: ['']) , ' SIZE=' , size printString , '>';
	 cr.
	values do: 
		[:value | 
		stream nextPutAll: '<OPTION'.
		(selections includes: value)
			ifTrue: [stream nextPutAll: ' SELECTED'].
		stream nextPutAll: '>'.
		stream nextPutAll: value;
		 cr].
	stream nextPutAll: '</SELECT>'.
	^ stream contents