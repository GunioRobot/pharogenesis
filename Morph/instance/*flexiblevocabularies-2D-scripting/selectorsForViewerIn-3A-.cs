selectorsForViewerIn: aCollection
	"Answer a list of symbols representing all the selectors available in all my viewer categories, selecting only the ones in aCollection"

	| aClass aList itsAdditions added addBlock |
	aClass := self renderedMorph class.
	aList := OrderedCollection new.
	added := Set new.
	addBlock := [ :sym |
		(added includes: sym) ifFalse: [ (aCollection includes: sym)
			ifTrue: [ added add: sym. aList add: sym ]]].

	[aClass == Morph superclass] whileFalse: 
			[(aClass hasAdditionsToViewerCategories) 
				ifTrue: 
					[itsAdditions := aClass allAdditionsToViewerCategories.
					itsAdditions do: [ :add | add do: [:aSpec |
									"the spec list"

									aSpec first == #command ifTrue: [ addBlock value: aSpec second].
									aSpec first == #slot 
										ifTrue: 
											[ addBlock value: (aSpec seventh).
											 addBlock value: aSpec ninth]]]].
			aClass := aClass superclass].

	^aList copyWithoutAll: #(#unused #dummy)

	"SimpleSliderMorph basicNew selectorsForViewerIn: 
	#(setTruncate: getColor setColor: getKnobColor setKnobColor: getWidth setWidth: getHeight setHeight: getDropEnabled setDropEnabled:)
	"