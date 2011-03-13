squeakToMac
	"Convert the receiver from Squeak to MacRoman encoding"
	self deprecated: 'Not necessary anymore with unicode fixes'.
	^ self class new setString: string squeakToMac setRuns: runs copy