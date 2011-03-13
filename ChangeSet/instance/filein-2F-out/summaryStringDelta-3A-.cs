summaryStringDelta: delta 
	"Answer the string summarizing this changeSet"
	| ps s2 date author line intName |
	^ String streamContents: 
		[ :s | 
		intName := self name splitInteger.
		intName first isNumber 
			ifTrue: [ s nextPutAll: (intName first + delta) printString , intName last ]
			ifFalse: [ s nextPutAll: intName first	"weird convention of splitInteger" ].
		(ps := self preambleString) 
			ifNil: [ s cr ]
			ifNotNil: 
				[ s2 := ps readStream.
				s2
					match: 'Date:';
					skipSeparators.
				date := s2 upTo: Character cr.
				s2
					match: 'Author:';
					skipSeparators.
				author := s2 upTo: Character cr.
				s
					nextPutAll: ' -- ';
					nextPutAll: author;
					nextPutAll: ' -- ';
					nextPutAll: date;
					cr.
				[ s2 atEnd ] whileFalse: 
					[ line := s2 upTo: Character cr.
					(line isEmpty or: [ line = '"' ]) ifFalse: 
						[ s
							nextPutAll: line;
							cr ] ] ] ]