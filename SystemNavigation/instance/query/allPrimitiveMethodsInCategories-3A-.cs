allPrimitiveMethodsInCategories: aList 
	"Answer an OrderedCollection of all the methods that are implemented by 
	primitives in the given categories. 1/26/96 sw"
	"SystemNavigation new allPrimitiveMethodsInCategories:  
	#('Collections-Streams' 'Files-Streams' 'Files-Abstract' 'Files-Macintosh')"

	| aColl method |
	aColl := OrderedCollection new: 200.
	Cursor execute
		showWhile: [self
				allBehaviorsDo: [:aClass | (aList includes: (SystemOrganization categoryOfElement: aClass theNonMetaClass name asString) asString)
						ifTrue: [aClass
								selectorsDo: [:sel | 
									method := aClass compiledMethodAt: sel.
									method primitive ~= 0
										ifTrue: [aColl addLast: aClass name , ' ' , sel , ' ' , method primitive printString]]]]].
	^ aColl