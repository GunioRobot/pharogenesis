drawAcceleratedOutlineOn: aRenderer
	"Draw a pooh outline on an accelerated renderer."
	| vtxList scale out pt vtx offset z |
	"NOTE: The test below captures two distinct cases.
		#1: The software renderer (which does not support lines)
		#2: The D3D renderer (which does not support line attributes)."
	myRenderer hasFrameBufferAccess ifTrue:[
		^myRenderer provideOverlayCanvasDuring:[:cc| self sketchOn: cc].
	].
	z _ 0.5.
	vtxList _ self outline contents.
	vtxList size < 2 ifTrue:[^self].
	out _ WriteStream on: (B3DVector3Array new: vtxList size * 2).
	out nextPut: vtxList first @ z.
	2 to: vtxList size-1 do:[:i|
		pt _ vtxList at: i.
		vtx _ B3DVector3 x: pt x y: pt y z: z.
		out nextPut: vtx; nextPut: vtx].
	out nextPut: vtxList last @ z.
	out _ out contents.

	offset _ bounds origin + bounds corner * 0.5 @ 0.
	scale _ (2.0 / bounds extent x) @ (-2.0 / bounds extent y) @ 1.

	myRenderer reset. "get rid of everything"
	myRenderer material: (B3DMaterial new emission: Color red).
	myRenderer scaleBy: scale.
	myRenderer translateBy: offset negated.
	myRenderer lineWidth: 5.
	myRenderer drawLines: out normals: nil colors: nil texCoords: nil.
