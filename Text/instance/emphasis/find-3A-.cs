find: attribute
	"Return the first interval over which this attribute applies"
	| begin end |
	begin _ 0.
	runs withStartStopAndValueDo:
		[:start :stop :attributes |
		(attributes includes: attribute)
			ifTrue: [begin = 0 ifTrue: [begin _ start].
					end _ stop]
			ifFalse: [begin > 0 ifTrue: [^ begin to: end]]].
	begin > 0 ifTrue: [^ begin to: end].
	^ nil