step
	| wb |

	owner ifNil: [^ self].
	(self ownerThatIsA: HandMorph) ifNotNil: [^self].
	self checkForRebuild.
	owner == self world ifTrue: [
		owner addMorphInLayer: self.
		wb _ self worldBounds.
		self left < wb left ifTrue: [self left: wb left].
		self right > wb right ifTrue: [self right: wb right].
		self positionVertically.
	].