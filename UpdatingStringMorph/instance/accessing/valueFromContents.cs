valueFromContents
	"Return a new value from the current contents string."

"
	| expression tilePadMorphOrNil asNumberBlock |
	asNumberBlock _ [:string | [string asNumber]
				on: Error
				do: []].
	format = #string
		ifTrue: [^ contents].
	(format = #default
			and: [self owner isKindOf: NumericReadoutTile])
		ifTrue: [^ asNumberBlock value: contents].
	tilePadMorphOrNil _ self ownerThatIsA: TilePadMorph.
	(tilePadMorphOrNil notNil
			and: [tilePadMorphOrNil type = #Number])
		ifTrue: [^ asNumberBlock value: contents].
	expression _ Vocabulary eToyVocabulary translationKeyFor: contents.
	expression isNil
		ifTrue: [expression _ contents].
	^ Compiler evaluate: expression
"

	format = #symbol ifTrue: [^ lastValue].
	format = #string ifTrue: [^ contents].
	^ Compiler evaluate: contents
