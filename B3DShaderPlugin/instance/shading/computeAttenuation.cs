computeAttenuation
	"Compute the attenuation for the current light and vertex"
	lightScale _ 1.0.
	(lightFlags anyMask: FlagAttenuated) ifTrue:[
		lightScale _ 1.0 / ((primLight at: PrimLightAttenuationConstant) + 
			(l2vDistance * ((primLight at: PrimLightAttenuationLinear) + 
				(l2vDistance * (primLight at: PrimLightAttenuationSquared)))))].
