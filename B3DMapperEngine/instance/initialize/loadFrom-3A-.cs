loadFrom: aRenderEngine
	"Load our components from the given render engine.
	The idea is that all of the state is shared so that transformations
	send during picking will be preserved in the given render engine."
	vertexBuffer _ aRenderEngine getVertexBuffer.
	transformer _ aRenderEngine getTransformer.
	shader _ aRenderEngine getShader.
	clipper _ aRenderEngine getClipper.
	rasterizer _ aRenderEngine getRasterizer. 