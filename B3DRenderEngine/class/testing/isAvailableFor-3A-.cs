isAvailableFor: anOutputMedium
	"Return true if this engine is available for the given output medium"
	^(self transformer isAvailableFor: anOutputMedium)  and:[
		(self shader isAvailableFor: anOutputMedium) and:[
			(self clipper isAvailableFor: anOutputMedium) and:[
				(self rasterizer isAvailableFor: anOutputMedium)]]]