rgbaBitMasks
	"Return the masks for specifying the R,G,B, and A components in the receiver"
	display 
		ifNil:[^super rgbaBitMasks]
		ifNotNil:[^display rgbaBitMasksOfForm: self]