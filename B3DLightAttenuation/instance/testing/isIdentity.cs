isIdentity
	"Return true if the attenuation results in a constant lighting"
	^self constantPart = 1.0
		and:[self linearPart = 0.0
			and:[self squaredPart = 0.0]]