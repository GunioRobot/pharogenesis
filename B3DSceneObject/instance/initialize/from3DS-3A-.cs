from3DS: aDictionary
	aDictionary isEmpty ifTrue:[^nil].
	geometry _ B3DSTriangleMesh from3DS: aDictionary.
	material _ (aDictionary at: #triList) last.