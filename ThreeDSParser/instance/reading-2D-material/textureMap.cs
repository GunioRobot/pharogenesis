textureMap
	| name percent |
	name := nil.
	percent := 1.0.
	self recognize:#(
		(16rA300 cString texName)
		(16r0030 short texPercent)
		(16r0031 float texPercent))
	do:[:item|
		item key == #texName ifTrue:[name := item value].
		item key == #texPercent ifTrue:[percent := item value / 100.0]].
	^Array 	with:(#textureName -> name)
			with: (#texturePercentage -> percent).