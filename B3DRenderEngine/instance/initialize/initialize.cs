initialize
	engine _ self. "Obviously ;-)"
	vertexBuffer _ B3DVertexBuffer new.
	transformer _ self class transformer engine: self.
	shader _ self class shader engine: self.
	clipper _ self class clipper engine: self.
	rasterizer _ self class rasterizer engine: self.
	self materialColor: Color white.