testExternalReferenceOf
	| r cls1 cls2 cls3 |
	cls1 _ self createClass: #MyClass1.
	cls2 _ self createClass: #MyClass2.
	cls3 _ self createClass: #MyClass3.
	"-------"
	cls1 compile: 'foo ^ MyClass2'.
	cls1 compile: 'bar MyClass1 show: ''blah blah'''.
	cls1 compile: 'zork OrderedCollection new'.
	cls1 compile: 'baz Morph new openInWorld'.
	"-------"
	cls2 compile: 'foo ^ Object'.
	cls2 compile: 'bar Transcript show: ''blah blah'''.
	cls2 compile: 'zork OrderedCollection new'.
	"-------"
	cls3 compile: 'foo ^ Object'.
	cls3 compile: 'bar Transcript show: ''blah blah'''.
	cls3 compile: 'zork MyClass3 new'.
	"-------"
	r _ Analyzer
				externalReferenceOf: (#(#MyClass1 #MyClass2 #MyClass3 )
						collect: [:clsName | Smalltalk at: clsName]).
	self assert: r size = 4.
	self
		assert: (r includesAllOf: #(#Object #Transcript #OrderedCollection #Morph )).
