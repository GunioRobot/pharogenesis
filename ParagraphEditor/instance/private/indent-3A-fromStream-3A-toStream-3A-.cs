indent: delta fromStream: inStream toStream: outStream
	"Append the contents of inStream to outStream, adding or deleting delta or -delta
	 tabs at the beginning, and after every CR except a final CR.  Do not add tabs
	 to totally empty lines, and be sure nothing but tabs are removed from lines."

	| ch skip cr tab prev atEnd |
	cr _ Character cr.
	tab _ Character tab.
	delta > 0
		ifTrue: "shift right"
			[prev _ cr.
			 [ch _ (atEnd _ inStream atEnd) ifTrue: [cr] ifFalse: [inStream next].
			  (prev == cr and: [ch ~~ cr]) ifTrue:
				[delta timesRepeat: [outStream nextPut: tab]].
			  atEnd]
				whileFalse:
					[outStream nextPut: ch.
					prev _ ch]]
		ifFalse: "shift left"
			[skip _ delta. "a negative number"
			 [inStream atEnd] whileFalse:
				[((ch _ inStream next) == tab and: [skip < 0]) ifFalse:
					[outStream nextPut: ch].
				skip _ ch == cr ifTrue: [delta] ifFalse: [skip + 1]]]