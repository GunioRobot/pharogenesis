checkScopes: aClass from: classList

	"DynamicInterpreter checkScopes: DynamicContextCache from: DynamicInterpreterState"

	"DynamicInterpreter checkScopes: DynamicTranslator from: DynamicContextCache"

	"DynamicInterpreter checkScopes: DynamicInterpreter from: DynamicContextCache"
	"DynamicInterpreter checkScopes: DynamicInterpreter from: DynamicTranslator"

	"DynamicInterpreter checkScopes: DynamicInterpreter from: { DynamicContextCache. DynamicTranslator }"

	"Open a message list browser on those methods that refer to instance variables defined outside their class."

	| foreignVars msgList refList varSet |
	foreignVars _ IdentitySet new.
	classList do: [:theClass | foreignVars addAll: theClass instVarNames].
	refList _ Dictionary new.
	varSet _ Set new.
	foreignVars do: [:var |
		(aClass whichSelectorsAccess: var) do: [:sel |
			(refList at: sel ifAbsent: [refList at: sel put: Set new]) add: var.
			varSet add: var.]].
	Transcript cr; cr;
		nextPutAll: 'The following inherited instance variables were referenced in ' , aClass name , ':';
		crtab.
	varSet asSortedCollection do: [:var | Transcript nextPutAll: var; space].
	Transcript endEntry.
	msgList _ Set new.
	refList associationsDo: [:assoc |
		msgList add: (String streamContents: [:str |
			str nextPutAll: aClass name; space; nextPutAll: assoc key; nextPutAll: '  ( '.
			assoc value do: [:var | str nextPutAll: var; space].
			str nextPut: $)])].
	Smalltalk
		browseMessageList: msgList asSortedCollection
		name: 'foreign inst var accesses'