createMorphicListsFrom: arrayOfLists 
	| array |
	font
		ifNil: [font _ Preferences standardListFont].
	array _ Array new: arrayOfLists size.
	1 to: arrayOfLists size do: [:arrayIndex |
		array at: arrayIndex put: (
			(arrayOfLists at: arrayIndex) collect: [:item | item isText
						ifTrue: [StringMorph
								contents: item
								font: font
								emphasis: (item emphasisAt: 1)]
						ifFalse: [StringMorph contents: item font: font]])
		].
	^array