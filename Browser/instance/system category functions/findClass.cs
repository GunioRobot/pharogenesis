findClass
	"Search for a class by name."
	| pattern foundClassOrTrait |

	self okToChange ifFalse: [^ self classNotFound].
	pattern := UIManager default request: 'Class name or fragment?'.
	pattern isEmptyOrNil ifTrue: [^ self classNotFound].
	foundClassOrTrait := SystemNavigation default classFromPattern: pattern withCaption: ''.
	foundClassOrTrait ifNil: [^ self classNotFound].
 	self selectCategoryForClass: foundClassOrTrait.
	self selectClass: foundClassOrTrait.
