parsingFinished
	"figure out who our constituents are"

	self allSubentitiesDo: [ :e |
		e isFormEntity ifTrue: [ e form: self ] ].
	super parsingFinished.
	formEntities _ OrderedCollection new.
	self allSubentitiesDo: [ :e |
		(e isFormEntity and: [ e form == self ])
			ifTrue: [ formEntities add: e ] ].