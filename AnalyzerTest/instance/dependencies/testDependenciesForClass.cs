testDependenciesForClass
	| cls r |
	cls _ self createClass: #MyClass.
	"-------"
	cls compile: 'foo ^ Object'.
	cls compile: 'bar Transcript show: ''blah blah'''.
	cls compile: 'zork OrderedCollection new'.
	"-------"
	r _ Analyzer dependenciesForClass: cls.
	self assert: r size = 3.
	self
		assert: (r includesAllOf: #(#Object #Transcript #OrderedCollection )).
