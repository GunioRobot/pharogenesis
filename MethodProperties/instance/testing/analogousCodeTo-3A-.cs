analogousCodeTo: aMethodProperties
	pragmas
		ifNil: [aMethodProperties pragmas notEmpty ifTrue: [^false]]
		ifNotNil:
			[aMethodProperties pragmas isEmpty ifTrue: [^false].
			 pragmas size ~= aMethodProperties pragmas size ifTrue:
				[^false].
			 pragmas with: aMethodProperties pragmas do:
				[:mine :others|
				(mine analogousCodeTo: others) ifFalse: [^false]]].
	^(self hasAtLeastTheSamePropertiesAs: aMethodProperties)
	  and: [aMethodProperties hasAtLeastTheSamePropertiesAs: self]