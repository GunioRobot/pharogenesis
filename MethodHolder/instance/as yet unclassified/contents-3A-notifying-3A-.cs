contents: input notifying: aController 
	| selector |
	(selector _ Parser new parseSelector: input asText) ifNil:
		[self inform: 'Sorry - invalid format for the 
method name and arguments -- cannot accept.'.
		^ false].

	selector == methodSelector ifFalse:
		[self inform:
'You cannot change the name of
the method here -- it must continue
to be ', methodSelector.
		^ false].

	selector _ methodClass
				compile: input asText
				classified: self selectedMessageCategoryName
				notifying: aController.
	selector == nil ifTrue: [^ false].
	contents _ input asString copy.
	currentCompiledMethod _ methodClass compiledMethodAt: methodSelector.
	^ true