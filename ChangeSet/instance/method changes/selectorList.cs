selectorList
	"answer a set of all the selectors represented in the change set"
	"Smalltalk changes selectorList"
	| aList |
	aList _ OrderedCollection new.
	methodChanges associationsDo: 
		[:clAssoc | 
		clAssoc value associationsDo: 
			[:mAssoc |
			(#(remove addedThenRemoved) includes: mAssoc value) ifFalse:
				[aList add: mAssoc key]]].
	^ aList asSet