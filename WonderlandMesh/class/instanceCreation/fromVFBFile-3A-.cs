fromVFBFile: filename
	"Reads and creates a mesh from an OBJ file"

	^ (WonderlandMesh new) createFromVFBFile: filename.
