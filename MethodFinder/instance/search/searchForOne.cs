searchForOne
	"Look for and return just one answer"

	expressions _ WriteStream on: (String new: 400).
	self search: false.	"non-multi"
	^ expressions contents
			