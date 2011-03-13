trickyPrimitiveList
	"InterpreterSupportCode trickyPrimitiveList"

	| primitives internal method index ivars |
	"Instance variables of Interpreter that we might have to setup before running a primitive"
	ivars _ #(activeContext argumentCount instructionPointer lkupClass messageSelector
			method newMethod primitiveIndex receiver stackPointer successFlag theHomeContext).
	Interpreter initialize.
	primitives _ self internalPrimitives asArray.
	primitives _ IdentityDictionary withAll: ('scanning for reachable methods...' withCRs
		displayProgressAt: Sensor cursorPoint
		from: 1 to: primitives size
		during: [:bar |
			primitives withIndexCollect: [:sel :seq |
				bar value: seq.
				sel -> (self selectorsReachableFrom: sel)]]).
	internal _ Dictionary new.
	('scanning for inst var refs...' withCRs
		displayProgressAt: Sensor cursorPoint
		from: 1 to: ivars size
		during: [:bar |
			ivars withIndexCollect: [:ivar :seq |
				bar value: seq.
				index _ Interpreter allInstVarNames indexOf: ivar.
				ivar -> (primitives select: [:sels |
							nil ~~ (sels detect: [:sel |
											method _ (Interpreter compiledMethodAt: sel).
											(method readsField: index) or: [method writesField: index]]
										ifNone: [nil])]) keys]])
		associationsDo: [:assoc |
			assoc value do: [:sel |
				(internal at: sel ifAbsent: [internal at: sel put: Set new])
					add: assoc key]].
	primitives keysDo: [:sel | (internal includesKey: sel) ifFalse: [internal at: sel put: Set new]].
	internal addAll: (self externalPrimitives collect: [:prim | prim -> #(argumentCount stackPointer successFlag)]).
	(internal at: #primitiveStoreImageSegment) removeAll:
		#(activeContext lkupClass messageSelector method newMethod receiver).
	internal at: #primitiveFlushCache put:
		#(stackPointer activeFrame).
	^(internal associationsDo: [:assoc | assoc value: assoc value asSortedCollection])