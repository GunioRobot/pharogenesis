defineVBConstants: dict
	"Initialize the vertex buffer constants"
	"B3DPoolDefiner initPool"
	self initFromSpecArray:
	#(
		"Vertex color tracking flags. These tracks define what part of 
		the material in the shader is determined by the vertex color (if given)."
		(VBTrackAmbient 1)		"ambient part"
		(VBTrackDiffuse 2)		"diffuse part"
		(VBTrackSpecular 4)		"specular part"
		(VBTrackEmission 8)		"emission part -- i.e. simply add vertex color to output"
		(VBNoTrackMask 4294967280) "Mask out the above flags"

		"Vertex attribute flags. These flags determine if the primitive
		vertices include these attributes. Note that color is not included
		below - it is fully specified by the color tracking flags above."
		(VBVtxHasNormals 16)	"per vertex normals included"
		(VBVtxHasTexCoords 32)	"per vertex tex coords inclueded"

		"Shader flags stored in the vertex buffer"
		(VBTwoSidedLighting 64)	"Do we shade front and back faces differently?!"
		(VBUseLocalViewer 128)	"Do we use a local viewer model for specular colors?!"
	) in: dict.