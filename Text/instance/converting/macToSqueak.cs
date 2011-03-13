macToSqueak
	"Convert the receiver from MacRoman to Squeak encoding"
	self deprecated: 'Not necessary anymore with unicode fixes'.
	^ self class new setString: string macToSqueak setRuns: runs copy