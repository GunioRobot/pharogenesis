categoryDefiningSelector: aSelector
	"Answer a category in which aSelector occurs"

	| categoryNames |
	categoryNames _ categoryList copyWithoutAll: #('-- all --').
	^ currentVocabulary categoryWithNameIn: categoryNames thatIncludesSelector: aSelector forInstance: self targetObject ofClass: targetClass