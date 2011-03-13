fixCollisionsFrom: oldIndex
	"The element at index has been removed and replaced by nil."
	self rehash. "Do it the hard way - we may have any number of nil keys and #rehash deals with them"