prepareForAlanDemo
	"EToySystem prepareForAlanDemo"
	EToyParameters enterAlanDemoMode.
	EToyWorld allInstancesDo:
		[:aWorld | aWorld prepareForAlanDemo].
	(Smalltalk at: #Actor) allInstances do:  "Can't use allInstancesDo: here"
		[:anInst | anInst become: (anInst as: SketchMorph)]