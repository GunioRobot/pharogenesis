allPrimitiveMethodsInCategories: aList
	"Answer an OrderedCollection of all the methods that are implemented by primitives in the given categories.  1/26/96 sw"

	| aColl aSelector method | 
	aColl _ OrderedCollection new: 200.
	Cursor execute showWhile: 
		[self allBehaviorsDo: 
			[:aClass | (aList includes: (SystemOrganization categoryOfElement: aClass theNonMetaClass name asString) asString)
				ifTrue: [aClass selectorsDo: 
					[:sel | 
						method _ aClass compiledMethodAt: sel.
						method primitive ~= 0
							ifTrue: [aColl addLast: aClass name , ' ' , sel 
									, ' ' , method primitive printString]]]]].
	^ aColl

"Smalltalk allPrimitiveMethodsInCategories: #('Collections-Streams' 'Files-Streams' 'Files-Abstract' 'Files-Macintosh')"