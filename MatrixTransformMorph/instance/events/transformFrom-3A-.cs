transformFrom: uberMorph
	(owner isNil or:[owner == uberMorph]) ifTrue:[^self transform].
	^(owner transformFrom: uberMorph) asMatrixTransform2x3 composedWithLocal: self transform