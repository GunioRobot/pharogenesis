pluginTransformData: forward
	"Plugin testing -- if the primitive is not implemented 
	or cannot be found run the simulation. See also: FFTPlugin"
	<primitive: 'primitiveFFTTransformData'>
	^FFTPlugin doPrimitive: 'primitiveFFTTransformData'.