scheduleDelay: aDelay
	"Private. Schedule this Delay."
	aDelay beingWaitedOn: true.
	ActiveDelay ifNil:[
		ActiveDelay := aDelay
	] ifNotNil:[
		aDelay resumptionTime < ActiveDelay resumptionTime ifTrue:[
			SuspendedDelays add: ActiveDelay.
			ActiveDelay := aDelay.
		] ifFalse: [SuspendedDelays add: aDelay].
	].
