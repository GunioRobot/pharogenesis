rectifyActorPrototypeClasses  "Wonderland rectifyActorPrototypeClasses"
	"Rectify any obsolete prototype class references"

	ActorPrototypeClasses keysDo:
		[:key | (ActorPrototypeClasses at: key) isObsolete ifTrue:
				[ActorPrototypeClasses at: key
					put: (ActorPrototypeClasses at: key) nonObsoleteClass]]
