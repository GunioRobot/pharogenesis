preparePrimitiveInClass: aClass
	"Add a prolog and postlog to a primitive method. The prolog copies any instance variables referenced by this primitive method into local variables. The postlog copies values of assigned-to variables back into the instance. The names of the new locals are added to the local variables list.

The declarations dictionary defines the types of any non-integer variables (locals, arguments, or instance variables). In particular, it may specify the types:

	int *		-- an array of 32-bit values (e.g., a BitMap)
	short *		-- an array of 16-bit values (e.g., a SoundBuffer)
	char *		-- an array of unsigned bytes (e.g., a String)
	double		-- a double precision floating point number (e.g., 3.14159)

Undeclared variables are taken to be integers and will be converted from Smalltalk to C ints."

"Current restrictions:
	o method must not contain message sends
	o method must not allocate objects
	o method must not manipulate raw oops
	o method cannot access class variables
	o method can only return an integer"

	"ar 10/7/1998 -- 	Add the export directive for translated primitives.
				--	Use the name of the primitive if it's called by name."

	| prolog postlog instVarsUsed varsAssignedTo instVarList primArgCount varName endsWithReturn |
	prolog _ OrderedCollection new.
	postlog _ OrderedCollection new.
	instVarsUsed _ self freeVariableReferences asSet.
	varsAssignedTo _ self variablesAssignedTo asSet.
	instVarList _ aClass allInstVarNames.
	primArgCount _ args size.

	"add receiver fetch and arg conversions to prolog"
	prolog addAll: self fetchRcvrExpr.
	1 to: args size do: [:argIndex |
		varName _ args at: argIndex.
		prolog addAll:
			(self argConversionExprFor: varName stackIndex: args size - argIndex)].

	"add success check to postlog"
	postlog addAll: self checkSuccessExpr.

	"add instance variable fetches to prolog and instance variable stores to postlog"
	1 to: instVarList size do: [:varIndex |
		varName _ instVarList at: varIndex.
		(instVarsUsed includes: varName) ifTrue: [
			locals add: varName.
			prolog addAll: (self instVarGetExprFor: varName offset: varIndex - 1).
			(varsAssignedTo includes: varName) ifTrue: [
				postlog addAll: (self instVarPutExprFor: varName offset: varIndex - 1)]]].
	prolog addAll: self checkSuccessExpr.

	locals addAllFirst: args.
	locals addFirst: 'rcvr'.
	args _ args class new.
	locals asSet size = locals size
		ifFalse: [self error: 'local name conflicts with instance variable name'].
	endsWithReturn _ self endsWithReturn.
	self fixUpReturns: primArgCount postlog: postlog.

	"Check for pluggable primitive"
	primitive = 117 
		ifTrue:[selector _ ((aClass includesSelector: selector)
					ifTrue: [aClass compiledMethodAt: selector]
					ifFalse: [aClass class compiledMethodAt: selector]) literals first at: 2.
				export _ true]
		ifFalse:[selector _ 'prim', aClass name, selector].

	endsWithReturn
		ifTrue: [parseTree setStatements: prolog, parseTree statements]
		ifFalse: [
			postlog addAll: (self popArgsExpr: primArgCount).
			parseTree setStatements: prolog, parseTree statements, postlog].
