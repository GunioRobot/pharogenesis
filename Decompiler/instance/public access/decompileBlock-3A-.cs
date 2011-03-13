decompileBlock: aBlock 
	"Decompile aBlock, returning the result as a BlockNode.  
	Show temp names from source if available."

	| startpc end homeClass blockNode home |

	(home := aBlock home) ifNil: [^ nil].
	(homeClass := home methodClass) ifNil: [^ nil].
	method := home method.
	constructor := DecompilerConstructor new.
	
	self withTempNames: method methodNode tempNames.
	
	self initSymbols: homeClass.
	startpc _ aBlock startpc.
	end _ aBlock endPC.
	stack _ OrderedCollection new: method frameSize.
	caseExits _ OrderedCollection new.
	statements _ OrderedCollection new: 20.
	super method: method pc: startpc - 5.
	blockNode _ self blockTo: end.
	stack isEmpty ifFalse: [self error: 'stack not empty'].
	^ blockNode statements first
	
	"Decompiler new decompileBlock: [3 + 4]"