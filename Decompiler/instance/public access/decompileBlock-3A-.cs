decompileBlock: aBlock 
	"Original version timestamp: sn 1/26/98 18:27
	(Don't know who's sn?) "
	"Decompile aBlock, returning the result as a BlockNode.  
	Show temp names from source if available."
	"Decompiler new decompileBlock: [3 + 4]"
	| startpc end homeClass blockNode tempNames home source |
	(home _ aBlock home) ifNil: [^ nil].
	method _ home method.
	(homeClass _ home who first) == #unknown ifTrue: [^ nil].
	constructor _ DecompilerConstructor new.
	method fileIndex ~~ 0
		ifTrue: ["got any source code?"
			source _ [method getSourceFromFile]
						on: Error
						do: [:ex | ^ nil].
			tempNames _ ([homeClass compilerClass new
						parse: source
						in: homeClass
						notifying: nil]
						on: (Smalltalk classNamed: 'SyntaxErrorNotification')
						do: [:ex | ^ nil]) tempNames.
			self withTempNames: tempNames].
	self initSymbols: homeClass.
	startpc _ aBlock startpc.
	end _ (method at: startpc - 2)
				\\ 16 - 4 * 256
				+ (method at: startpc - 1) + startpc - 1.
	stack _ OrderedCollection new: method frameSize.
	caseExits _ OrderedCollection new.
	statements _ OrderedCollection new: 20.
	super method: method pc: startpc - 5.
	blockNode _ self blockTo: end.
	stack isEmpty ifFalse: [self error: 'stack not empty'].
	^ blockNode statements first