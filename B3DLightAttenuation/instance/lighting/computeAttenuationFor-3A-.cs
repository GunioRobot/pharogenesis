computeAttenuationFor: distance
	"Compute the light attenuation for the given distance"
	^1.0 / (self constantPart + 
			(distance * (self linearPart + 
				(distance * self squaredPart))))