makeGCList		"DynamicInterpreter checkGC"
	"Answer an Array containing all methods in the interpreter hierarchy that might provoke a GC.
	It suffices to find all transitive callers of fullGC, since an incrementalGC calls this when the root
	table is full."

	| classList selectors newSelectors prevSize messages newMessages |
	classList _ Set new
				add: ObjectMemory;
				add: DynamicInterpreterState;
				add: DynamicContextCache;
				add: DynamicTranslator;
				add: DynamicInterpreter;
		yourself.
	selectors _ Set with: #fullGC.
	messages _ Set new.
	[prevSize _ selectors size.
	newSelectors _ Set new.
	newMessages _ Set new.
	classList do: [:aClass |
		aClass selectors do: [:sel |
			((aClass compiledMethodAt: sel) literals detect: [:lit | selectors includes: lit] ifNone: [])
				isNil ifFalse:
					[newSelectors add: sel.
					newMessages add: aClass name , ' ' , sel.]]].
	selectors addAll: newSelectors.
	messages addAll: newMessages.
	newSelectors size = prevSize]
		whileFalse.
	^Array with: selectors asSortedCollection with: messages asSortedCollection