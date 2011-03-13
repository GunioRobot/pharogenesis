allPrimitiveMessages
	"Answer an OrderedCollection of all the methods that are implemented by 
	primitives."

	| aColl aSelector method | 
	aColl _ OrderedCollection new: 200.
	Cursor execute showWhile: 
		[self allBehaviorsDo: 
			[:class | class selectorsDo: 
				[:sel | 
				method _ class compiledMethodAt: sel.
				method primitive ~= 0
					ifTrue: [aColl addLast: class name , ' ' , sel 
									, ' ' , method primitive printString]]]].
	^aColl