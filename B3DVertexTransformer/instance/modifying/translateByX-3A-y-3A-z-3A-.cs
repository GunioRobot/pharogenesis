translateByX: x y: y z: z
	"Add the translation defined by aVector to the current matrix"
	currentMatrix translateByX: x y: y z: z.
	needsUpdate := true.