noteDangerous
	"Remember the methods with really bad side effects."

	Dangerous _ Set new.
"Object accessing, testing, copying, dependent access, macpal, flagging"
	#(addInstanceVarNamed:withValue: haltIfNil copyAddedStateFrom: veryDeepCopy veryDeepCopyWith: veryDeepFixupWith: veryDeepInner: addDependent: evaluate:wheneverChangeIn: codeStrippedOut: playSoundNamed: isThisEverCalled isThisEverCalled: logEntry logExecution logExit)
		do: [:sel | Dangerous add: sel].

"Object error handling"
	#(cannotInterpret: caseError confirm: confirm:orCancel: doesNotUnderstand: error: halt halt: notify: notify:at: primitiveFailed shouldNotImplement subclassResponsibility tryToDefineVariableAccess:)
		do: [:sel | Dangerous add: sel].

"Object user interface"
	#(basicInspect beep inform: inspect inspectWithLabel: notYetImplemented inspectElement )
		do: [:sel | Dangerous add: sel].

"Object system primitives"
	#(become: becomeForward: instVarAt:put: instVarNamed:put: nextInstance nextObject rootStubInImageSegment: someObject tryPrimitive:withArgs:)
		do: [:sel | Dangerous add: sel].

"Object private"
	#(errorImproperStore errorNonIntegerIndex errorNotIndexable errorSubscriptBounds: mustBeBoolean primitiveError: species storeAt:inTempFrame:)
		do: [:sel | Dangerous add: sel].

"Object, translation support"
	#(cCode: cCode:inSmalltalk: cCoerce:to: export: inline: returnTypeC: sharedCodeNamed:inCase: var:declareC:)
		do: [:sel | Dangerous add: sel].

"Object, objects from disk, finalization.  And UndefinedObject"
	#(comeFullyUpOnReload: objectForDataStream: readDataFrom:size: rehash saveOnFile storeDataOn: actAsExecutor executor finalize retryWithGC:until:   suspend)
		do: [:sel | Dangerous add: sel].

"No Restrictions:   Boolean, False, True, "

"Morph"
	#()
		do: [:sel | Dangerous add: sel].

"Behavior"
	#(obsolete confirmRemovalOf: copyOfMethodDictionary literalScannedAs:notifying: storeLiteral:on: addSubclass: removeSubclass: superclass: 
"creating method dictionary" addSelector:withMethod: compile: compile:notifying: compileAll compileAllFrom: compress decompile: defaultSelectorForMethod: methodDictionary: recompile:from: recompileChanges removeSelector: compressedSourceCodeAt: selectorAtMethod:setClass: allInstances allSubInstances inspectAllInstances inspectSubInstances thoroughWhichSelectorsReferTo:special:byte: "enumerating" allInstancesDo: allSubInstancesDo: allSubclassesDo: allSuperclassesDo: selectSubclasses: selectSuperclasses: subclassesDo: withAllSubclassesDo:
   "too slow->" crossReference removeUninstantiatedSubclassesSilently "too slow->" unreferencedInstanceVariables
"private" becomeCompact becomeUncompact flushCache format:variable:words:pointers: format:variable:words:pointers:weak: printSubclassesOn:level: basicRemoveSelector: addSelector:withMethod:notifying: addSelectorSilently:withMethod:)
		do: [:sel | Dangerous add: sel].

"CompiledMethod"
	#(defaultSelector)
		do: [:sel | Dangerous add: sel].

"Others "
	#("no tangible result" do: associationsDo:  
"private" adaptToCollection:andSend: adaptToNumber:andSend: adaptToPoint:andSend: adaptToString:andSend: instVarAt:put: asDigitsToPower:do: combinations:atATimeDo: doWithIndex: pairsDo: permutationsDo: reverseDo: reverseWith:do: with:do: withIndexDo: asDigitsAt:in:do: combinationsAt:in:after:do: errorOutOfBounds permutationsStartingAt:do: fromUser)
		do: [:sel | Dangerous add: sel].


	#(    fileOutPrototype addSpareFields makeFileOutFile )
		do: [:sel | Dangerous add: sel].
	#(recompile:from: recompileAllFrom: recompileChanges asPrototypeWithFields: asPrototype addInstanceVarNamed:withValue: addInstanceVariable addClassVarName: removeClassVarName: findOrAddClassVarName: tryToDefineVariableAccess: instanceVariableNames: )
		do: [:sel | Dangerous add: sel].

 