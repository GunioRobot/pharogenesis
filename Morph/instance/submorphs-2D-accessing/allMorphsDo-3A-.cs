allMorphsDo: aBlock
	"Evaluate the given block for all morphs in this composite morph (including the receiver)."

	submorphs size > 0 ifTrue: [
		submorphs do: [:m | m allMorphsDo: aBlock].
	].
	aBlock value: self.
