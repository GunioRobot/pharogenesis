searchForOne
	"Look for and return just one answer"

	expressions _ OrderedCollection new.
	self search: false.	"non-multi"
	^ expressions
			