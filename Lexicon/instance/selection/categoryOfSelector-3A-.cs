categoryOfSelector: aSelector 
	"Answer the name of the defining category for aSelector, or nil if none"
	| classDefiningSelector |
	classDefiningSelector _ targetClass whichClassIncludesSelector: aSelector.
	classDefiningSelector
		ifNil: [^ nil].
	"can happen for example if one issues this from a change-sorter for a 
	message that is recorded as having been removed"
	^ classDefiningSelector whichCategoryIncludesSelector: aSelector