interpolateFrom: last to: next at: t
	"Interpolate the primitive vertices last/next at the parameter t"
	| out |
	out _ next clone.
	"Interpolate raster position"
	out rasterPos: ((next rasterPos - last rasterPos) * t) + last rasterPos.
	out clipFlags: (self clipFlagsX: out rasterPosX y: out rasterPosY z: out rasterPosZ w: out rasterPosW).
	"Interpolate color"
	out b3dColor: ((next b3dColor - last b3dColor) * t) + last b3dColor.
	"Interpolate texture coordinates"
	out texCoords: ((next texCoords - last texCoords) * t) + last texCoords.
	^out