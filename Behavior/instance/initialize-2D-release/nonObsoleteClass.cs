nonObsoleteClass
	"Attempt to find and return the current version of this obsolete class"

	| obsName |
	obsName _ self name.
	[obsName beginsWith: 'AnObsolete']
		whileTrue: [obsName _ obsName copyFrom: 'AnObsolete' size + 1 to: obsName size].
	^ self environment at: obsName asSymbol