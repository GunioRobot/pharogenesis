extent: extentPoint depth: bitsPerPixel
	"Create a new MaskedForm that is blank.  All of it is transparent."

	^ self new setForm: (Form extent: extentPoint depth: bitsPerPixel)
		mask: (Form extent: extentPoint) "one bit deep, transparent" 
		removeOverlap: false
