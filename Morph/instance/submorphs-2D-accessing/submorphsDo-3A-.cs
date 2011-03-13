submorphsDo: aBlock

	submorphs size = 0 ifTrue: [^ self].
	submorphs do: aBlock.