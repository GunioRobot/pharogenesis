createActorFor: aMesh name: aString suffix: suffix
	| actor |
	actor _ myWonderland createSimpleActor: aMesh 
					named: aString, suffix
					parent: currentActor.
	"actor setMaterial: (attributes at: #currentMaterial ifAbsent:[nil])."
	aMesh == nil ifFalse:[attributes at: #currentShape put: actor].
	^actor