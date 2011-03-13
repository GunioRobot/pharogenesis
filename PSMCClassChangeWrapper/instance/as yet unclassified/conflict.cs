conflict
	"Answer the conflict for the class itself or nil if none."

	|o|
	conflict ifNotNil: [^conflict].
	o := self model detect: [:i | i targetClassName == self item and: [
				i definition isClassDefinition]] ifNone: [].
	o ifNil: [^nil].
	o isConflict ifTrue: [conflict := o].
	^conflict