rectifyActorClassList  "Wonderland allInstancesDo: [:w | w rectifyActorClassList]"
	"Attempt to restore the actorClassList by replacing obsolete classes by current classes of the same name"

	actorClassList _ actorClassList collect:
		[:obs |
		(obs name beginsWith: 'AnObsolete')
			ifTrue: [obs nonObsoleteClass]
			ifFalse: [obs]]