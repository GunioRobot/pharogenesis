buttonBarFor: aServiceCategory 
	self styleBar: self bar.
	aServiceCategory enabledServices
		do: [:each | self bar
				addMorphBack: (self buttonFor: each)].
	^ self bar