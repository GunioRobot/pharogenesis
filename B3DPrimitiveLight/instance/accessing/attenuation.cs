attenuation
	"Return the light attenuation.
	This member is only valid if the light is attenuated."
	^B3DLightAttenuation
		constant: self constantAttenuation
		linear: self linearAttenuation
		squared: self squaredAttenuation