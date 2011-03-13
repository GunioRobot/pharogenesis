fullDraw: aMorph

	aMorph canDrawAtHigherResolution ifTrue: [
		deferredMorphs ifNil: [deferredMorphs _ OrderedCollection new].
		deferredMorphs add: aMorph.
	] ifFalse: [
		super fullDraw: aMorph
	].