removeHtmlMarkupFrom: in 

	| out |
 
	out := ReadWriteStream on: (String new: 100).
	[ in atEnd ] whileFalse: [ 
		out nextPutAll: (in upTo: $<).
		(((in upTo: $>) asLowercase beginsWith: 'br') and: [ (in peek = Character cr) ]) ifTrue: [ in next ].	
	].
	
	^self replaceEntitiesIn: out reset.
