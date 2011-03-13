initPrimitives   "ContextPart initPrimitives"
	"The methods (from class Object) that are cached in tryPrimitiveMethods 
	are used by the simulator to catch failures when simulating primitives."
	TryPrimitiveSelectors _
#(tryPrimitive
tryPrimitiveWith:
tryPrimitiveWith:with:
tryPrimitiveWith:with:with:
tryPrimitiveWith:with:with:with:
tryPrimitiveWith:with:with:with:with:
tryPrimitiveWith:with:with:with:with:with:).
	TryPrimitiveMethods _
		TryPrimitiveSelectors collect:  [:sel | Object compiledMethodAt: sel]