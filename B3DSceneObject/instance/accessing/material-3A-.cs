material: aMaterial
	material _ aMaterial.
	material class == Association ifTrue:[
		texture _ material key.
		material _ material value.
	].