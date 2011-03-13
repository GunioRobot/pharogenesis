chooseCategory
	"The mouse went down on my category-list control; pop up a list of category choices"

	| aList aMenu reply aLinePosition lineList |
	aList := scriptedPlayer categoriesForViewer: self.

	aLinePosition := aList indexOf: #miscellaneous ifAbsent: [nil].
	aList := aList collect:	
		[:aCatSymbol | self currentVocabulary categoryWordingAt: aCatSymbol].

	lineList := aLinePosition ifNil: [#()] ifNotNil: [Array with: aLinePosition].
	aList size == 0 ifTrue: [aList add: ScriptingSystem nameForInstanceVariablesCategory translated].
	aMenu := CustomMenu labels: aList lines: lineList selections: aList.
	reply := aMenu startUpWithCaption: 'category' translated.
	reply ifNil: [^ self].
	self chooseCategoryWhoseTranslatedWordingIs: reply asSymbol
