removeActorPrototypesFromSystem
	"Clean out all the actor prototypes - this involves removing those classes from the Smalltalk dictionary"

	ActorPrototypeClasses do: [:aClass | aClass removeFromSystem ].

	ActorPrototypeClasses _ Dictionary new.
