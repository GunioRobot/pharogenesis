addMorphsAndModel: aDummyWorld
	"Dump in submorphs, model, and stepList from a dummyWorld.  Used to bring a world in from an object file.  "

	| |
	aDummyWorld isMorph ifTrue: [
		aDummyWorld isWorldMorph ifFalse: ["one morph, put on hand"
			"aDummyWorld installModelIn: self.  	a chance to install model pointers"
			self startSteppingSubmorphsOf: aDummyWorld.
			self hands first attachMorph: aDummyWorld
		] ifTrue: [
			model == nil ifTrue: [self setModel: (aDummyWorld modelOrNil)]
					ifFalse: [aDummyWorld modelOrNil ifNotNil: [
								aDummyWorld modelOrNil privateOwner: nil.
								self addMorph: (aDummyWorld modelOrNil)]].
			aDummyWorld privateSubmorphs reverseDo: [:m |
				m privateOwner: nil.
				self addMorph: m.
				m changed].
			(aDummyWorld instVarNamed: 'stepList') do:
				[:entry | entry first startStepping]]

	] ifFalse: ["list, add them all"
		aDummyWorld reverseDo: [:m |
			m privateOwner: nil.
			self addMorph: m.
			self startSteppingSubmorphsOf: m.	"It may not want this!"
			m changed]].
