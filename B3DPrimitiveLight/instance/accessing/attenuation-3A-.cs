attenuation: aLightAttenuation
	"Set the light attenuation.
	This member is only valid if the light is attenuated."
	self constantAttenuation: aLightAttenuation constantPart.
	self linearAttenuation: aLightAttenuation linearPart.
	self squaredAttenuation: aLightAttenuation squaredPart.