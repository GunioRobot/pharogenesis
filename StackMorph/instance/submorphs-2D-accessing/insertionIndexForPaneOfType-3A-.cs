insertionIndexForPaneOfType: aType
	| naturalIndex insertionIndex |
	naturalIndex _ self naturalPaneOrder indexOf: aType.
	insertionIndex _ 1.
	(self naturalPaneOrder copyFrom: 1 to: (naturalIndex - 1)) do: "guys that would precede"
		[:sym | (self hasSubmorphWithProperty: sym)
			ifTrue:
				[insertionIndex _ insertionIndex + 1]].
	^ insertionIndex