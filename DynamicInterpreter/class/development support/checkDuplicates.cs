checkDuplicates
	"DynamicInterpreter checkDuplicates"
	"Browse source conflicts in DynamicInterpreter hierarchy"

	| conflicts selectors classes messages |
	classes _ IdentitySet new
				add: ObjectMemory;
				add: DynamicInterpreterState;
				add: DynamicContextCache;
				add: DynamicTranslator;
				add: DynamicInterpreter;
				yourself.
	selectors _ Bag new.
	classes do: [:cls | selectors addAll: cls selectors].
	conflicts _ (selectors select: [:elt | (selectors occurrencesOf: elt) > 1]) asSet.
	conflicts isEmpty
		ifTrue:
			[PopUpMenu notify: 'No duplicates in ' , selectors size printString , ' methods']
		ifFalse:
			[messages _ OrderedCollection new.
			 conflicts do: [:sel |
				classes do: [:cls |
					(cls selectors includes: sel)
						ifTrue: [messages add: cls name , ' ' , sel]]].
			 Smalltalk
				browseMessageList: messages asSortedCollection
				name: 'DynamicInterpreter conflicts'].
	^{classes. selectors}