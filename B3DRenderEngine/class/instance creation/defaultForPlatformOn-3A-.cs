defaultForPlatformOn: aForm
	"Return the render engine that is most appropriate for the current host platform."
	(B3DHardwareEngine isAvailableFor: aForm) 
		ifTrue:[^B3DHardwareEngine newOn: aForm].
	(B3DPrimitiveEngine isAvailableFor: aForm) 
		ifTrue:[^B3DPrimitiveEngine newOn: aForm].
	^B3DRenderEngine newOn: aForm