assureVertexNormals
	| vtx |
	1 to: self size do:[:i|
		vtx _ self at: i.
		vtx normal == nil ifTrue:[
			vtx _ vtx copy.
			vtx normal: self normal.
			self at: i put: vtx]].