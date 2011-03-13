categoriesContaining: aSelector forClass: aTargetClass 
	"Answer a list of category names (all symbols) of categories that contain 
	the given selector for the target object. Initially, this just returns one."
	| classDefiningSelector catName |
	classDefiningSelector := aTargetClass whichClassIncludesSelector: aSelector.
	classDefiningSelector
		ifNil: [^ OrderedCollection new].
	catName := classDefiningSelector whichCategoryIncludesSelector: aSelector.
	^ OrderedCollection with: catName