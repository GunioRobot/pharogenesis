setLimit: sizeLimit limitBlock: aBlock
	"Limit the numer of elements this stream will write..."
	limit _ sizeLimit.
	"Execute this (typically ^ contents) when that limit is exceded"
	limitBlock _ aBlock