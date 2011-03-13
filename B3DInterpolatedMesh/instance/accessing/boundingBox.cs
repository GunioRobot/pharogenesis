boundingBox
	| box origin corner |
	box _ meshes first boundingBox.
	origin _ box origin.	corner _ box corner.
	2 to: meshes size do:[:i|
		box _ (meshes at: i) boundingBox.
		origin _ origin min: box origin.
		corner _ corner max: box corner.
	].
	^Rectangle origin: origin corner: corner