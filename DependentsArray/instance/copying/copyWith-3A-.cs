copyWith: newElement 
	"Re-implemented to not copy any niled out dependents"
	^self class streamContents:[:s|
		self do:[:item| s nextPut: item].
		s nextPut: newElement].