translateInDirectory: directory doInlining: inlineFlag
"Special case for the 3D code. Check all the classes' timestamps, not just one"
	| cg fname fstat tStamp|
	 fname _ self moduleName, '.c'.
	tStamp _ 0.

	tStamp _ { B3DEnginePlugin. B3DTransformerPlugin. B3DVertexBufferPlugin. B3DShaderPlugin. B3DClipperPlugin. B3DPickerPlugin. B3DRasterizerPlugin} inject: 0 into: [:tS :cl|
		tS _ tS max: cl timeStamp].

	"don't translate if the file is newer than my timeStamp"
	fstat _ directory entryAt: fname ifAbsent:[nil].
	fstat ifNotNil:[tStamp < fstat modificationTime ifTrue:[^nil]].

	self initialize.

	cg _ self buildCodeGeneratorUpTo: InterpreterPlugin.

	{ B3DEnginePlugin. B3DTransformerPlugin. B3DVertexBufferPlugin. B3DShaderPlugin. B3DClipperPlugin. B3DPickerPlugin. B3DRasterizerPlugin} do: 
		[:theClass | 
		theClass initialize.
		cg addClass: theClass.
		theClass declareCVarsIn: cg].
	cg storeCodeOnFile: (directory fullNameFor: fname)  doInlining: inlineFlag.
	^cg exportedPrimitiveNames asArray