isDone
	"Returns true if the Action is done executing either because it's lifetime has expired or because the specified condition is true"

	(lifetime > 0) ifTrue: [^ (lifetime < (myScheduler getTime))]
				ifFalse: [^ (stopCondition value)].
	