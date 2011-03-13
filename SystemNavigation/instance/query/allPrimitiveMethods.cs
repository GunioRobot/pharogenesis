allPrimitiveMethods
	"Answer an OrderedCollection of all the methods that are implemented by primitives."
	| aColl method |
	aColl := OrderedCollection new: 200.
	Cursor execute
		showWhile: [self allBehaviorsDo: [:class | class
						selectorsDo: [:sel | 
							method := class compiledMethodAt: sel.
							method primitive ~= 0
								ifTrue: [aColl addLast: class name , ' ' , sel , ' ' , method primitive printString]]]].
	^ aColl