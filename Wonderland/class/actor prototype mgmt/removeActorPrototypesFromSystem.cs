removeActorPrototypesFromSystem
	"Clean out all the actor prototypes - this involves removing those classes from the Smalltalk dictionary"

	WonderlandActor withAllSubclassesDo:[:each|
		each isSystemDefined ifFalse:[each removeFromSystem].
	].
	ActorPrototypeClasses _ Dictionary new.
