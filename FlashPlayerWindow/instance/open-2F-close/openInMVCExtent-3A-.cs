openInMVCExtent: extent
	Smalltalk isMorphic ifTrue:[^self openInWorldExtent: extent].
	super openInMVCExtent: (extent + borderWidth + (0@self labelHeight))