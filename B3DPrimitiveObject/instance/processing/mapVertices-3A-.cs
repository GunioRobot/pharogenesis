mapVertices: viewport
	"Map all the vertices in the receiver"
	| xOfs yOfs xScale yScale w x y z scaledX scaledY first |
	xOfs _ (viewport origin x + viewport corner x) * 0.5 - 0.5.
	yOfs _ (viewport origin y + viewport corner y) * 0.5 - 0.5.
	xScale _ (viewport corner x - viewport origin x) * 0.5.
	yScale _ (viewport corner y - viewport origin y) * -0.5.
	bounds _ 16r3FFFFFFF asPoint extent: 0@0.
	minZ _ maxZ _ 0.0.
	first _ true.
	vertices do:[:vtx|
		w _ vtx rasterPosW.
		w = 0.0 ifFalse:[w _ 1.0 / w].
		x _ vtx rasterPosX * w * xScale + xOfs.
		y _ vtx rasterPosY * w * yScale + yOfs.
		z _ vtx rasterPosZ * w.
		vtx rasterPosW: w.
		vtx rasterPosZ: z.
		scaledX _ (x * 4096.0) asInteger.
		scaledY _ (y * 4096.0) asInteger.
		vtx windowPosX: scaledX.
		vtx windowPosY: scaledY.
		true ifTrue:[
			vtx rasterPosX: scaledX / 4096.0.
			vtx rasterPosY: scaledY / 4096.0.
		] ifFalse:[
			vtx rasterPosX: x.
			vtx rasterPosY: y.
		].
		first ifTrue:[
			bounds _ scaledX@scaledY extent: 0@0.
			minZ _ maxZ _ z.
			first _ false.
		] ifFalse:[
			bounds _ bounds encompass: scaledX@scaledY.
			minZ _ minZ min: z. 
			maxZ _ maxZ max: z.
		].
	].
	bounds _ (bounds origin bitShiftPoint: -12) corner: (bounds corner bitShiftPoint: -12).