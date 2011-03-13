testWith
	"self debug: #testWith"
	
	| aCol element |
	element := self collectionMoreThan5Elements anyOne.
	aCol := self collectionClass with: element.
	self assert: (aCol includes: element).