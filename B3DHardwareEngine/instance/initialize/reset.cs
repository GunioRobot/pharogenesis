reset
	super reset.
	self primRender: handle setModelView: nil projection: nil.
	self primRender: handle setLights: nil.
	self primRender: handle setMaterial: nil.
