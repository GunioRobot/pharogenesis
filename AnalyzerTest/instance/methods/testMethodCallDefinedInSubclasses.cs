testMethodCallDefinedInSubclasses
	| cls1 cls2 r |
	cls1 _ self createClass: #MyClass1.
	cls2 _ self createClass: #MyClass2 superclass: cls1.
	"-------"
	cls1 compile: 'foo ^ self bar'.
	cls2 compile: 'bar ^ true'.
	"-------"
	self assert: cls2 new foo.
	r _ Analyzer
				methodsIn: cls1
				callingMethodsDefinedIn: (Array with: cls2).
	r _ r asOrderedCollection.
	self assert: r size = 1.
	self assert: r first size = 2.
	self assert: r first first == #foo.
	self assert: r first second == #bar.
