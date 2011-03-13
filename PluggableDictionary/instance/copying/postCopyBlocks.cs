postCopyBlocks
	hashBlock _ hashBlock copy.
	equalBlock _ equalBlock copy.
	"Fix temps in case we're referring to outside stuff"
	hashBlock ifNotNil: [hashBlock fixTemps].
	equalBlock ifNotNil: [equalBlock fixTemps]