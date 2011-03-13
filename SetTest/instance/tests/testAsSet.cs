testAsSet
	"could be moved in Array or Collection"

	| newFull |
	newFull := #(#abc 5) asSet.
	newFull add: 5.
	self assert: (newFull = full).