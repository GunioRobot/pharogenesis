disassemble: tMeth

	"Select the following line:
			DynamicTranslator disassemble: (thisContext copy instVarAt: 5)
	and then 'inspect it' for a quick demonstration.
	(Try implementing *that* in Java!)"

	| opNames word constants defaultPrinter printers |
	opNames _ self opcodeNameMap.
	constants _ { nil. true. false }.
	defaultPrinter _	 [:w |
		'	' , ((constants includes: w)
			ifTrue: [w printString]
			ifFalse: ['<' , w class printString , '>'])].
	printers _ IdentityDictionary new
		at: SmallInteger			put: [:w | opNames at: w ifAbsent: ['	' , w printString]];
		at: Symbol				put: [:w | '	' , w printString];
		at: TranslatedMethod		put: [:w | '	[' , (self headerStringOf: w) , ']'];
		at: Association			put: [:w | '	Association' , ((w key isMemberOf: Symbol)
																ifTrue: [' #' , w key]
																ifFalse: [''])];
		yourself.
	^String streamContents: [:str |
		str	nextPutAll: (self headerStringOf: tMeth); cr.
		MethodOpcodeStart + 1 to: tMeth size do: [:pc |
			word _ tMeth at: pc.
			str	print: pc; tab;
				nextPutAll: ((printers at: word class ifAbsent: [defaultPrinter]) value: word);
				cr]]