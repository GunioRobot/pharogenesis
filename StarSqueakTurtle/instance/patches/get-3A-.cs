get: patchVar
	"Answer the value of the given patch variable below this turtle."

	^ world getPatchVariable: patchVar atX: x y: y
