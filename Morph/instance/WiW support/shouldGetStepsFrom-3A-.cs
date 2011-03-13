shouldGetStepsFrom: aWorld

	self world == aWorld ifTrue: [^true].
	(self ownerThatIsA: HandMorph) ifNotNil: [^true].
	^false