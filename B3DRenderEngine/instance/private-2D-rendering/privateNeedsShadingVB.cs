privateNeedsShadingVB
	"Return true if the objects in the vertex buffer needs separate shading.
	This is determined by checking if
		a) lighting is enabled
		b) at least one light exists
		c) at least one material exists
	"
	^true