moveContentsToFront
	"Need to update crc here"
	self updateCrc.
	super moveContentsToFront.
	crcPosition _ position + 1.