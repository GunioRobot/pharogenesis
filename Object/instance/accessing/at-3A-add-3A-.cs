at: index add: amount
	"Add a number to an element of a collection"
	self at: index put: (self at: index) + amount