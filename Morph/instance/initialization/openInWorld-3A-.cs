openInWorld: aWorld
	"Add this morph to the requested World."
	(aWorld viewBox origin ~= (0@0) and: [self position = (0@0)]) ifTrue:
		[self position: aWorld viewBox origin].
	aWorld addMorph: self.
	aWorld startSteppingSubmorphsOf: self