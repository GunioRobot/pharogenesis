renderOn: aRenderer
	material ifNotNil:[
		aRenderer pushMaterial.
		aRenderer material: material].
	texture ifNotNil:[
		aRenderer pushTexture.
		aRenderer texture: texture].
	matrix ifNotNil:[
		aRenderer pushMatrix.
		aRenderer transformBy: matrix].
	geometry ifNotNil:[geometry renderOn: aRenderer].
	children ifNotNil:[children do:[:child| child renderOn: aRenderer]].
	matrix ifNotNil:[aRenderer popMatrix].
	texture ifNotNil:[aRenderer popTexture].
	material ifNotNil:[aRenderer popMaterial].