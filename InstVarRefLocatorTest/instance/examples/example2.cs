example2
	| ff|	
	ff := 1.
	(1 < 2) ifTrue: [ff ifNotNil: [ff _ 'hallo']].
	^ ff.