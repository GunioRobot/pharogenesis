worldMorphsDo: aBlock
	"Evaluate the given block for all worlds in this composite morph (including the receiver).
	May be overriden to save looking in useless places."

	submorphs size > 0 ifTrue:
		[submorphs do: [:m | m worldMorphsDo: aBlock]].
	self isWorldMorph ifTrue: [aBlock value: self]