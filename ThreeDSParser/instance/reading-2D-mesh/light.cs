light
	"Subchunk of namedObject"

	| pos lightSpec |
	pos := self vector3.
	lightSpec := self recognize: #(
		(16r0010 colorFloat color)		"Color of light source"
		(16r0011 color24 color)		"Color of light source"
		(16r4610 spot ->)				"Spot light specs, see #spot"
		(16r4620 flag off)			"Light off flag (default on)"
		(16r4659 float innerRange)	"Attenuation min range"
		(16r465A float outerRange)	"Attenuation max range"
		(16r465B float multiplier))	"Intensity multiplier (default 1.0)"
		as: Dictionary.
	lightSpec at: #position put: pos.
	^(lightSpec includesKey: #spot )
		ifTrue: [self spotLightClass from3DS: lightSpec]
		ifFalse:[self pointLightClass from3DS: lightSpec]