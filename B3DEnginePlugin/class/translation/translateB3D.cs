translateB3D
	"B3DEnginePlugin translateB3D"
	"Translate all the basic plugins into one support module 
	and write the C sources for the rasterizer."
	| cg |
	cg _ PluggableCodeGenerator new initialize.
		cg declareModuleName: self moduleNameAndVersion local: false.

	{InterpreterPlugin. B3DEnginePlugin. B3DTransformerPlugin. B3DVertexBufferPlugin. B3DShaderPlugin. B3DClipperPlugin. B3DPickerPlugin. B3DRasterizerPlugin} do: 
		[:theClass | 
		theClass initialize.
		cg addClass: theClass.
		theClass declareCVarsIn: cg].
	cg storeCodeOnFile: self moduleName , '.c' doInlining: true.
	"	cg storeCodeOnFile: '/tmp/Ballon3D.c' doInlining: true."
	B3DRasterizerPlugin writeSupportCode: true