decayPatchVariable: patchVarName
	"Decay the values of the patch variable of the given name. That is, the value of each patch is replaced by a fraction of its former value, resulting in an expontial decay each patch's value over time. This can be used to model evaporation of a pheromone."

	| patchVar |
	patchVar := patchVariables at: patchVarName ifAbsent: [^ self].
	self primEvaporate: patchVar rate: scaledEvaporationRate.

