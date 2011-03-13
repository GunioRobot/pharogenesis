testTraitsUsersSanity
	"This documents bug http://code.google.com/p/pharo/issues/detail?id=443"
	"self debug: #testTraitsUsersSanity"
	
	Smalltalk allClassesAndTraits do: [ :each |
		self assert: (each traits allSatisfy: [ :t | t users includes: each  ]) ].

	Smalltalk allTraits do: [ :each |
		self assert: (each users allSatisfy: [ :b | b traits includes: each ]) ]