translateOn: cg inlining: inlineFlag to: fullName local: localFlag
	"do the actual translation"
	{InterpreterPlugin. B3DEnginePlugin. B3DTransformerPlugin. B3DVertexBufferPlugin. B3DShaderPlugin. B3DClipperPlugin. B3DPickerPlugin. B3DRasterizerPlugin} do: 
		[:theClass | 
		theClass initialize.
		cg addClass: theClass.
		theClass declareCVarsIn: cg].
	cg storeCodeOnFile: fullName doInlining: inlineFlag.
	B3DRasterizerPlugin writeSupportCode: true.
