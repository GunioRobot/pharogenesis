roundedCorners: anArray
	"Set the corners to round."

	super roundedCorners: anArray.
	self contentMorph ifNotNilDo: [:cm | cm roundedCorners: self roundedCorners]