recaptureUniqueCostumes
	"Recapture all unique sketch-like costumes. Debugging only."
	| unique |
	costumes ifNil:[^self].
	unique := PluggableSet new 
				equalBlock:[:s1 :s2| s1 form == s2 form];
				hashBlock:[:s| s form identityHash].
	unique addAll: (costumes select:[:c| c isKindOf: SketchMorph]).
	unique := unique asIdentitySet.
	costumes := costumes select:[:c|
		(c isKindOf: SketchMorph) not or:[unique includes: c]].
