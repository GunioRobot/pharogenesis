doChildrenOf: aVRMLNode
	| children |
	children := aVRMLNode children.
	children isNil ifTrue:[^self].
	children do:[:each| each doWith: self].