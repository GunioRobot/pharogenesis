readHeader
	"Set width and height, and position stream at start of bytes"
	| number setwidth setheight fieldName |
	setwidth _ setheight _ false.
		[((stream atEnd) or: [setwidth and: [setheight]])]
		whileFalse: [
	  	self skipCComments.
		(stream nextMatchAll: '#define ') ifFalse: [^ false].
		(stream skipTo: $_) ifFalse: [^ false].
		fieldName _ String streamContents:
			[:source |
			[(stream atEnd) or: [ stream peek isSeparator ]]
				whileFalse: [ source nextPut: stream next]].
	  	(fieldName = 'width') ifTrue: [
			stream skipSeparators.
			number _ Integer readFrom: stream.
			(number > 0) ifTrue: [setwidth _true].
	  		width _ number.].
		(fieldName = 'height') ifTrue: [
			stream skipSeparators.
			number _ Integer readFrom: stream.
			(number > 0) ifTrue: [setheight _ true].
			height _ number.
			].
		].
	(setwidth & setheight) ifFalse: [^ false].
	^ stream skipTo: ${
