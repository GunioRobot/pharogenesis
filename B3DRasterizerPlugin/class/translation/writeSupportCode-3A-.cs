writeSupportCode: inlineFlag
	"B3DRasterizerPlugin writeSupportCode: true"
	"B3DRasterizerPlugin writeSupportCode: false"
	"Translate all the C support files for the Balloon 3D rasterizer plugin."
	| src fs |
	#(
		(b3dTypesH 'b3dTypes.h')
		(b3dAllocH 'b3dAlloc.h')
		(b3dHeaderH 'b3d.h')

		(b3dInitC 'b3dInit.c')
		(b3dAllocC 'b3dAlloc.c')
		(b3dRemapC 'b3dRemap.c')
		(b3dDrawC 'b3dDraw.c')
		(b3dMainC 'b3dMain.c')
	) do:[:spec|
		src _ self perform: (spec at: 1).
		src _ self translateSupportCode: src inlining: inlineFlag.
		fs _ CrLfFileStream newFileNamed: (spec at: 2).
		fs nextPutAll: src.
		fs close.
	].