flipTexCoordV
	"Flip my v texture coordinates"
	vtxTexCoords ifNil:[^self].
	vtxTexCoords := vtxTexCoords collect:[:uv| uv u @ (1.0 - uv v negated)].
