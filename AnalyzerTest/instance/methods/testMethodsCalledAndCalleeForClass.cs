testMethodsCalledAndCalleeForClass
	| cls r |
	cls _ self createClass: #MyClass.
	"-------"
	cls compile: 'foo ^ Object'.
	cls compile: 'bar Transcript show: ''blah blah'''.
	cls compile: 'zork OrderedCollection new'.
	cls compile: 'foobar Object new asMorph; beep'.
	"-------"
	r _ Analyzer methodsCalledAndCalleeForClass: cls.
	self assert: r size = 3.
	self
		assert: (r includesAllOf: #(#(#bar #show:) #(#foobar #asMorph) #(#foobar #asMorph) )).
