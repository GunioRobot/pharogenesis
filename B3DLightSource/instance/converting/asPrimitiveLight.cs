asPrimitiveLight
	"Convert the receiver into a B3DPrimitiveLight that can be handled by the shader primitive directly. Light sources that cannot be represented as primitive should return nil. This will result in the callback of #shadeVertexBuffer from the shader."
	^nil