selectorsForViewer
	"Answer a list of symbols representing all the selectors available in all my viewer categories"

	| aClass aList itsAdditions added addBlock |
	aClass := self renderedMorph class.
	aList := OrderedCollection new.
	added := Set new.
	addBlock := [ :sym | (added includes: sym) ifFalse: [ added add: sym. aList add: sym ]].

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

	"SimpleSliderMorph basicNew selectorsForViewer"