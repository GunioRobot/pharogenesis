checkScopes: aClass

	"DynamicInterpreter checkScopes: DynamicContextCache"
	"DynamicInterpreter checkScopes: DynamicTranslator"
	"DynamicInterpreter checkScopes: DynamicInterpreter"

	"Open a message list browser on those methods that refer to
	instance variables defined outside their class."

	| theClass classList |
	classList _ OrderedCollection new.
	theClass _ aClass superclass.
	[theClass = ObjectMemory]
		whileFalse:
			[classList add: theClass.
			 theClass _ theClass superclass].
	self checkScopes: aClass from: classList