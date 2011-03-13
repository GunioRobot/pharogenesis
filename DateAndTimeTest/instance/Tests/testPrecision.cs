testPrecision
	"Verify that the clock is returning a value with accuracy of better than 1 second.  For now it seems sufficient to get two values and verify they are not the same."

	self
		assert: (DateAndTime now ~= DateAndTime now)
