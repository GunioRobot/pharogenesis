initialize
	"Do not call super initialize here. We get our components directly by the creating engine."
	pickList _ SortedCollection new: 100.
	pickList sortBlock:[:a1 :a2| a1 value rasterPosZ < a2 value rasterPosZ].
	objects _ OrderedCollection new: 100.
	objects resetTo: 1.
	maxVtx _ B3DPrimitiveVertex new.
	maxVtx rasterPosZ: 1.0e30.
	maxVtx rasterPosW: 1.0.