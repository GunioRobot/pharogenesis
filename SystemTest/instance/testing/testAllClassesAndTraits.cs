testAllClassesAndTraits
	"self debug: #testAllClassesAndTraits"
	
	| trait |
	trait := self t1.
	self assert: (Smalltalk allClassesAndTraits includes: trait).
	self deny: (Smalltalk allClasses includes: trait).
	