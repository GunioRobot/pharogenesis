test0FixtureTConvertAsSetForMultiplinessTest
	"a collection  with equal elements:"
	| res |
	self shouldnt: [ self withEqualElements]  raise: Error.

	res := true.
	self withEqualElements 
		detect: [ :each | (self withEqualElements occurrencesOf: each) > 1 ]
		ifNone: [ res := false ].
	self assert: res = true.

