atOrBelow: key ifAbsent: absentBlock
	| envt value maybe onDisk envName |
	"Compatibility hack -- find things in sub environments for now.
	Adjusted to not fault on every environment."

	^ super at: key ifAbsent:
		[onDisk _ OrderedCollection new.
		self associationsDo: [:assn | 
			((assn key endsWith: 'Environment')
				and: [assn key size > 'Environment' size]) ifTrue: [
				envName _ (assn key copyFrom: 1 to: assn key size - 11 "Environment") asSymbol.
				(envt _ super at: envName ifAbsent: [nil]) ifNotNil: [
					envt isInMemory 
						ifTrue: [((envt isKindOf: Environment) and: [envt ~~ self])
							ifTrue: [maybe _ true.
								value _ envt atOrBelow: key ifAbsent: [maybe _ false].
								maybe ifTrue: [^ value]]]
						ifFalse: [onDisk add: envName]]]].
		onDisk do: [:outName |
			(envt _ super at: outName ifAbsent: [nil]) ifNotNil: [
				((envt isKindOf: Environment) and: [envt ~~ self])
					ifTrue: [maybe _ true.
						value _ envt atOrBelow: key ifAbsent: [maybe _ false].
						maybe ifTrue: [^ value]]]].
		^ absentBlock value]