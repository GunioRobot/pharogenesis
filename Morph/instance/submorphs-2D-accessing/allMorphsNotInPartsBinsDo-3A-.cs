allMorphsNotInPartsBinsDo: aBlock
	"Evaluate the given block for all morphs in this composite morph (including the receiver) other than those that are, or reside in, a parts bin."

	self residesInPartsBin ifTrue: [^ self].
	submorphs size > 0 ifTrue:
		[submorphs do: [:m | m allMorphsNotInPartsBinsDo: aBlock]].
	aBlock value: self.
