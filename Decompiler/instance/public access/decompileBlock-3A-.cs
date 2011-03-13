decompileBlock: aBlock 
	"Decompile aBlock, returning the result as a BlockNode.  
	Show temp names from source if available."
	"Decompiler new decompileBlock: [3 + 4]"
	| startpc end homeClass blockNode methodNode home source |
	(home := aBlock home) ifNil: [^ nil].
	method := home method.
	(homeClass := home methodClass) ifNil: [^ nil].
	constructor := self constructorForMethod: aBlock method.
	method fileIndex ~~ 0 ifTrue: "got any source code?"
		[source := [method getSourceFromFile]
						on: Error
						do: [:ex | ^ nil].
		 methodNode := [homeClass compilerClass new
								parse: source
								in: homeClass
								notifying: nil]
							on: (Smalltalk classNamed: 'SyntaxErrorNotification')
							do: [:ex | ^ nil].
		 self withTempNames: methodNode schematicTempNamesString].
	self initSymbols: homeClass.
	startpc := aBlock startpc.
	end := aBlock isClosure
				ifTrue: [(method at: startpc - 2) * 256
					  + (method at: startpc - 1) + startpc - 1]
				ifFalse:
					[(method at: startpc - 2) \\ 16 - 4 * 256
					+ (method at: startpc - 1) + startpc - 1].
	stack := OrderedCollection new: method frameSize.
	caseExits := OrderedCollection new.
	statements := OrderedCollection new: 20.
	super
		method: method
		pc: (aBlock isClosure ifTrue: [startpc - 4] ifFalse: [startpc - 5]).
	aBlock isClosure ifTrue:
		[numLocalTemps := #decompileBlock: "Get pushClosureCopy... to hack fake temps for copied values"].
	blockNode := self blockTo: end.
	stack isEmpty ifFalse: [self error: 'stack not empty'].
	^blockNode statements first