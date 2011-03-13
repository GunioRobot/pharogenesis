defineMaterialAndLights: dict
	"Initialize constants used for materials and lights"
	"B3DPoolDefiner initPool"
	self initFromSpecArray:
	#(
		"MaterialColor stuff"
		(AmbientPart 0)
		(AmbientRed 0)
		(AmbientGreen 1)
		(AmbientBlue 2)
		(AmbientAlpha 3)

		(DiffusePart 4)
		(DiffuseRed 4)
		(DiffuseGreen 5)
		(DiffuseBlue 6)
		(DiffuseAlpha 7)

		(SpecularPart 8)	
		(SpecularRed 8)
		(SpecularGreen 9)
		(SpecularBlue 10)
		(SpecularAlpha 11)

		(MaterialColorSize 12)	"Size of B3DMaterialColor"

		"Material definition"
		(EmissionPart 12)
		(EmissionRed 12)
		(EmissionGreen 13)
		(EmissionBlue 14)
		(EmissionAlpha 15)

		(MaterialShininess 16)

		(MaterialSize 17)			"Size of B3DMaterial"

		"PrimitiveLight definition"
		(PrimLightPosition 12)
		(PrimLightPositionX 12)
		(PrimLightPositionY 13)
		(PrimLightPositionZ 14)

		(PrimLightDirection 15)
		(PrimLightDirectionX 15)
		(PrimLightDirectionY 16)
		(PrimLightDirectionZ 17)

		(PrimLightAttenuation 18)
		(PrimLightAttenuationConstant 18)
		(PrimLightAttenuationLinear 19)
		(PrimLightAttenuationSquared 20)

		(PrimLightFlags 21)
		"Spot light stuff"
		(SpotLightMinCos 22)
		(SpotLightMaxCos 23)
		(SpotLightDeltaCos 24)
		(SpotLightExponent 25)

		(PrimLightSize 32)		"Round up to power of 2"

		"Primitive light flags"
		(FlagPositional 16r0001)	"Light has an associated position"
		(FlagDirectional 16r0002)	"Light has an associated direction"
		(FlagAttenuated 16r0004)	"Light is attenuated"
		(FlagHasSpot 16r0008)	"Spot values are valid"
		(FlagAmbientPart 16r0100)	"Light has ambient part"
		(FlagDiffusePart 16r0200)	"Light has diffuse part"
		(FlagSpecularPart 16r0400)	"Light has specular part"

	) in: dict.