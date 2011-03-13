browseUncommentedMethodsWithInitials: targetInitials
	"Browse uncommented methods whose initials (in the time-stamp, as logged to disk) match the given initials.  Present them in chronological order.  CAUTION: It will take several minutes for this to complete."
	"Time millisecondsToRun: [SystemNavigation default browseUncommentedMethodsWithInitials: 'jm']"

	| initials timeStamp methodReferences cm |
	methodReferences _ OrderedCollection new.
	self  allBehaviorsDo:
		[:aClass | aClass selectors do: [:sel |
			cm _ aClass compiledMethodAt: sel.
			timeStamp _ Utilities timeStampForMethod: cm.
			timeStamp isEmpty ifFalse:
				[initials _ timeStamp substrings first.
				initials first isDigit ifFalse:
					[((initials = targetInitials) and: [(aClass firstPrecodeCommentFor: sel) isNil])
						ifTrue:
							[methodReferences add: (MethodReference new
								setStandardClass: aClass 
								methodSymbol: sel)]]]]].

	ToolSet
		browseMessageSet: methodReferences 
		name: 'Uncommented methods with initials ', targetInitials
		autoSelect: nil