textureColor: aTexture atS: sValue atT: tValue
	"Return the interpolated color of the given texture at s/t"
	| w h fragS fragT sIndex tIndex peeker tex00 tex01 tex10 tex11 sFrac tFrac mixed |
	w _ aTexture width.
	h _ aTexture height.
	fragS _ w * sValue.
	fragT _ h * tValue.
	sIndex _ fragS truncated.
	tIndex _ fragT truncated.
	peeker _ BitBlt current bitPeekerFromForm: aTexture.
	tex00 _ (peeker pixelAt: (sIndex \\ w)@(tIndex \\ h)) asColorOfDepth: aTexture depth.
	tex01 _ (peeker pixelAt: (sIndex+1 \\ w)@(tIndex \\ h)) asColorOfDepth: aTexture depth.
	tex10 _ (peeker pixelAt: (sIndex \\ w)@(tIndex+1 \\ h)) asColorOfDepth: aTexture depth.
	tex11 _ (peeker pixelAt: (sIndex+1 \\ w)@(tIndex+1 \\ h)) asColorOfDepth: aTexture depth.
	sFrac _ fragS \\ 1.0.
	tFrac _ fragT \\ 1.0.
	mixed _ ((1.0 - tFrac) * (((1.0 - sFrac) * tex00 asB3DColor) + (sFrac * tex01 asB3DColor))) +
			(tFrac * (((1.0 - sFrac) * tex10 asB3DColor) + (sFrac * tex11 asB3DColor))).
	^mixed