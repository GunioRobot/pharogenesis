postCopyBlocks
	keyBlock _ keyBlock copy.
	"Fix temps in case we're referring to outside stuff"
	keyBlock fixTemps.