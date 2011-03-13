allSubmorphNamesDo: aBlock

	super allSubmorphNamesDo: aBlock.
	aBlock value: self player getPatch externalName.
