setColor: aColor
	lightColor _ B3DMaterialColor new.
	lightColor ambientPart: aColor.
	lightColor diffusePart: aColor.
	lightColor specularPart: aColor.