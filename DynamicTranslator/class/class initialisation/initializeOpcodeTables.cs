initializeOpcodeTables			"DynamicTranslator initialize"

	"This method replaces the two separate initialisation methods for OpcodeTable and
	TranslatorOpcodeEncodings.  It enforces correspondance between encoding and position
	in the opcode dispatch table (which is only required for running the simulator)."

	| missing declared defined suspect recompile |
	TranslatorOpcodeEncodings = nil ifTrue:
		[TranslatorOpcodeEncodings _ IdentityDictionary new.
		self inform:
'DynamicTranslator>>TranslatorOpcodeEncodings initialised.

Unless you are filing-in this source code for the first time,
consider forcing recompilation of me and my subclasses.'].

	TranslatorOpcodeEncodings associationsDo: [:assoc | assoc value: 0].
	recompile _ false.

	"The following collection could be inferred from the defined selectors, but I prefer to keep the
	encodings predictable (and hence debuggable) for the moment.  The order is completely arbitrary."

	#(DoubleExtendedPushConstant DoubleExtendedPushLiteralVariable DoubleExtendedPushReceiverVariable DoubleExtendedSend DoubleExtendedStoreAndPopReceiverVariable DoubleExtendedStoreLiteralVariable DoubleExtendedStoreReceiverVariable DoubleExtendedSuper DuplicateTop Experimental ExtendedPushConstant ExtendedPushLiteralVariable ExtendedPushReceiverVariable ExtendedPushTemporaryVariable ExtendedStoreAndPopLiteralVariable ExtendedStoreAndPopReceiverVariable ExtendedStoreAndPopTemporaryVariable ExtendedStoreLiteralVariable ExtendedStoreReceiverVariable ExtendedStoreTemporaryVariable LongJumpIfFalse LongJumpIfTrue LongUnconditionalJump PopStack PrimAdd PrimAt PrimAtPut PrimBlockCopy PrimDivide PrimEqual PrimEquivalent PrimGreaterOrEqual PrimGreaterThan PrimLessOrEqual PrimLessThan PrimMultiply PrimNotEqual PrimPointX PrimPointY PrimSize PrimSubtract PrimValue PrimValueWithArg PushActiveContext PushConstant PushConstantFalse PushConstantMinusOne PushConstantNil PushConstantOne PushConstantTrue PushConstantTwo PushConstantZero PushLiteralConstant PushLiteralVariable PushReceiver PushReceiverVariable PushTemporaryVariable ReturnConstant ReturnReceiver ReturnTopFromBlock ReturnTopFromMethod SendLiteralSelector0 SendLiteralSelector1 SendLiteralSelector2 SendSpecialSelector ShortConditionalJump ShortUnconditionalJump SingleExtendedSend SingleExtendedSuper SpecialPrimitive StoreAndPopReceiverVariable StoreAndPopTemporaryVariable Unknown
	MacroMoveTempRcvr MacroPushTempTemp MacroPushInstTemp
	MacroPushTempConst MacroTempConstLessEq
	MacroTempConstAdd MacroTempConstAddTemp
	MacroTempTempAdd MacroTempTempSub MacroTempTempMul
	MacroTempTempAddTemp MacroTempTempSubTemp MacroTempTempMulTemp
	MacroConstAdd MacroConstSub MacroConstMul
	MacroConstPositiveBitShift MacroConstNegativeBitShift MacroConstBitAnd MacroConstBitOr
	MacroPopDup MacroPushBlock MacroUpLoopTest MacroLoopStep
	LinkedImmediateSend LinkedCompactSend LinkedNormalSend
	ExtendedImmediateSend ExtendedCompactSend ExtendedNormalSend
	DoubleExtendedImmediateSend DoubleExtendedCompactSend DoubleExtendedNormalSend)
		doWithIndex: [:opname :index |
			(TranslatorOpcodeEncodings includesKey: opname) ifFalse: [recompile _ true].
			(TranslatorOpcodeEncodings at: opname ifAbsent: [0]) = 0
				ifFalse: [self error: 'duplicated opcode: ' , opname].
			TranslatorOpcodeEncodings at: opname put: index].

	missing _ OrderedCollection new.
	TranslatorOpcodeEncodings associationsDo: [:assoc | assoc value = 0 ifTrue: [missing add: assoc]].
	missing isEmpty ifFalse:
		[(self confirm: (String streamContents: [:str |
			str nextPutAll: 'The following opcodes were not initialised:'; cr; cr.
			missing doWithIndex: [:assoc :i |
				i \\ 6 = 0 ifTrue: [str cr] ifFalse: [str space].
				str nextPutAll: assoc key].
			str cr; cr; nextPutAll: 'Shall I remove then from the encodings pool?']))
				ifTrue:
					[recompile _ true.		"paranoid, but safe"
					'Removing opcodes...'
							displayProgressAt: Sensor cursorPoint
							from: 0 to: missing size
							during: [:bar |
								missing doWithIndex: [:assoc :i |
									bar value: i.
									(Smalltalk allCallsOn: assoc) isEmpty
										ifTrue: [TranslatorOpcodeEncodings removeKey: assoc key]
										ifFalse: [self error: assoc key , ' is still referenced']]]]].

	OpcodeTableSize _ TranslatorOpcodeEncodings size.
	OpcodeTable _ Array new: OpcodeTableSize.
	TranslatorOpcodeEncodings associationsDo: [:assoc |
		OpcodeTable at: assoc value put: ('op' , assoc key) asSymbol].

	declared _ TranslatorOpcodeEncodings keys.
	defined _ DynamicTranslator selectors select: [:sel | sel beginsWith: 'op'].
	suspect _ declared reject: [:sel | defined includes: ('op' , sel) asSymbol].
	suspect isEmpty ifFalse:
		[Transcript cr; show: 'The following opcodes were declared but have no implementation:'; cr; tab.
		suspect do: [:sel | Transcript space; show: sel]].
	suspect _ defined reject: [:sel | declared includes: (sel copyFrom: 3 to: sel size) asSymbol].
	suspect isEmpty ifFalse:
		[Transcript cr; show: 'The following opcodes are implemented but have no implementation:'; cr; tab.
		suspect do: [:sel | Transcript space; show: sel]].

	recompile ifTrue:
		[(self confirm: 'Shared pools have been changed.  Shall I recompile
affected classes (highly recommended)?') ifTrue:
			[DynamicTranslator recompile: DynamicTranslator]]