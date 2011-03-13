doWrap
	"Determine whether a 'next' request at the end of my list should wrap around to the beginning, etc."

	self flag: #deferred.  "Hang this maybe on a property"
	^ true