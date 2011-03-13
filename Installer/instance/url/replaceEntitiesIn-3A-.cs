replaceEntitiesIn: in

	| out |
	
	out := ReadWriteStream on: (String new: 100).
	[ in atEnd ] whileFalse: [ 
		out nextPutAll: ((in upTo: $&) replaceAll: Character lf with: Character cr).
		in atEnd ifFalse: [ out nextPutAll: (self class entities at: (in upTo: $;) ifAbsent: '?') ].	
	].

	^out reset