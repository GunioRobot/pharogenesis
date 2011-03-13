diffusePatchVariable: patchVarName
	"Diffuse the patch variable of the given name."

	| v newV |
	diffusionRate = 0 ifTrue: [^ self].  "no diffusion"
	v := patchVariables at: patchVarName ifAbsent: [^ self].
	newV := Bitmap new: v size.
	self primDiffuseFrom: v
		to: newV
		width: dimensions x
		height: dimensions y
		delta: diffusionRate truncated.
	patchVariables at: patchVarName put: newV.
