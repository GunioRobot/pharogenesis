testMethodCallDefinedInSubclasses2
	| cls1 cls2 r cls3 cls4 |
	cls1 _ self createClass: #MyClass1.
	cls2 _ self createClass: #MyClass2 superclass: cls1.
	cls3 _ self createClass: #MyClass3.
	cls4 _ self createClass: #MyClass4 superclass: cls3.
	"-------"
	cls1 compile: 'foo ^ self f1; f2'.
	cls1 compile: 'bar ^ self f3; foo'.
	cls1 compile: 'zork ^ self bar; blah'.
	cls2 compile: 'f1 ^ true'.
	cls2 compile: 'f2 ^ true'.
	cls3 compile: 'f3 ^ true'.
	cls3 compile: 'foo ^ true'.
	cls4 compile: 'f3 ^ true'.
	cls4 compile: 'f4 ^ true'.
	cls4 compile: 'bleubleu ^ true'.
	cls4 compile: 'bouba ^ true'.
	"-------"
	r _ Analyzer
				methodsIn: cls1
				callingMethodsDefinedIn: (Array
						with: cls2
						with: cls3
						with: cls4).
	r _ r asOrderedCollection.
	self assert: r size = 3.
	self
		assert: (r includesAllOf: #(#(#foo #f1) #(#foo #f2) #(#bar #f3) )).
