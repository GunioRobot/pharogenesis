checkErrors
	"DynamicInterpreter checkErrors"

	| classes messages |
	classes _ (Set with: DynamicInterpreter with: DynamicContextCache with: DynamicInterpreter) asArray.
	messages _ Set new.
	classes do: [:aClass | messages addAll:
				((aClass selectors
					select: [:sel | (aClass compiledMethodAt: sel) literals includes: #error:])
					collect: [:sel | aClass name , ' ' , sel])].
	Smalltalk
		browseMessageList: messages asSortedCollection
		name: 'senders of #error: in ', classes printString
		autoSelect: #error: