release
	"We're done with compression. Do some cleanup."
	literals _ distances _ literalFreq _ distanceFreq _ nil.
	self updateCrc.
	encoder flushBits.
	self writeFooter.