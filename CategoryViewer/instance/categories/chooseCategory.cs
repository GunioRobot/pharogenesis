chooseCategory
	"The mouse went down on my category-list control; pop up a list of category choices"

	| aList aMenu reply aLinePosition lineList |
	aList _ scriptedPlayer categoriesForViewer: self.

	aLinePosition _ aList indexOf: #miscellaneous ifAbsent: [nil].
	aList _ aList collect:	
		[:aCatSymbol | self currentVocabulary categoryWordingAt: aCatSymbol].

	lineList _ aLinePosition ifNil: [#()] ifNotNil: [Array with: aLinePosition].
	aList size == 0 ifTrue: [aList add: ScriptingSystem nameForInstanceVariablesCategory translated].
	aMenu _ CustomMenu labels: aList lines: lineList selections: aList.
	reply _ aMenu startUpWithCaption: 'category' translated.
	reply ifNil: [^ self].
	self chooseCategoryWhoseTranslatedWordingIs: reply asSymbol
