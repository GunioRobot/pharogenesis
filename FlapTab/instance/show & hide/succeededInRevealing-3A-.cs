succeededInRevealing: aPlayer
	(super succeededInRevealing: aPlayer) ifTrue: [^ true].
	self flapShowing ifTrue: [^ false].
	(referent succeededInRevealing: aPlayer)
		ifTrue:
			[self showFlap.
			aPlayer costume addHalo.
			^ true].
	^ false