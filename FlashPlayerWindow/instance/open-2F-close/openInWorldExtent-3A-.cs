openInWorldExtent: extent
	Smalltalk isMorphic ifFalse:[^self openInMVCExtent: extent].
	super openInWorldExtent: (extent + borderWidth + (0@self labelHeight))