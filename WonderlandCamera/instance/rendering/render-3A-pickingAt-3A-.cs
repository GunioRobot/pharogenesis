render: aRenderEngine pickingAt: aPointOrNil
	"Render one frame of the Wonderland using this camera.
	If aPointOrNil is not nil then return the top most object at this point.
	Note: If picking, no objects are actually drawn."
	^self render: aRenderEngine pickingAt: aPointOrNil withPrimitiveVertex: false