initializeScriptHelp

" | helpDict |
	helpDict _ IdentityDictionary new.
	#(
	(aTest 'testing one two three')
 	(acceptScript:for: 'submit the contents of the given script editor as the code defining the given selector')
	(actorState 'return the ActorState object for the receiver, creating it if necessary')
	(addInstanceVariable 'start the interaction for adding a new instance variable to the receiver')
	(addPlayerMenuItemsTo:hand: 'add player-specific menu items to the given menu, on behalf of the given hand.  At present, these are only commands relating to the turtle')
	(addSlotNamedLike:withValue: 'add a slot with a unique name derived from the first parameter, giving it the second parameter as its initial value')
	(allScriptEditors 'answer a list off the extant ScriptEditors for the receiver')
	(anonymousScriptEditorFor: 'answer a new ScriptEditor object to serve as the place for scripting an anonymous (unnamed, unsaved) script for the receiver')
	(assignDecrGetter:setter:amt: 'evaluate the decrement variant of assignment')
	(assignGetter:setter:amt: 'evaluate the vanilla variant of assignment')
	(assignIncrGetter:setter:amt: 'evalute the increment version of assignment')
	(assignMultGetter:setter:amt: 'evaluate the multiplicative version of assignment')
	(assureEventHandlerRepresentsStatus 'make certain that the event handler associated with my current costume is set up to conform to my current script-status')
	(assureExternalName 'if I do not currently have an external name assigned, get one now')
	(assureUniClass 'make certain that I am a member a uniclass (i.e. a unique Player subclass); if I am not, create one now and become me into an instance of it')
	(availableCostumeNames 'answer a list of strings representing the names of all costumes currently available for me')
	(availableCostumesForArrows 'answer a list of actual, instantiated costumes for me, which can be cycled through as the user hits a next-costume or previous-costume button in a viewer')
	(beep: 'make the requested sound')
	(bounce: 'if I have just run into a boundary, bounce off of it, making the stated sound')
	(clearTurtleTrails 'erase all the pen trails within me')
	(deleteCard 'delete the current card')
	(firstPage 'make the first page of this book be the current one')
	(forward: 'move forward by the specified amount')
	(goto: 'make the given page be seen as my current page')
	(goToNextCard 'make the next card within me be the currently-visible one')
	(goToPreviousCard 'make the previous card within me be the currently-visible one')
	(goToRightOf: 'move me until I lie directly to the right of the other object.')
	(hide 'make me be invisible')
	(initiatePainting 'let the user start painting a new object with me')
	(lastPage 'make the last page of this book be the current one')
	(liftAllPens 'lift the pens of all the objects within me')
	(lowerAllPens 'lower the pens of all the objects within me')
	(moveToward: 'move toward another object')
	(newCard 'create a new card and make it my currently-visible one')
	(nextPage 'go to the next page following the current one')
	(pauseScript: 'make the specified script become paused')
	(previousPage 'go to the page preceding the current one.')
	(show 'make me be visible (if I was formerly hidden')
	(startScript: 'make the specified script start ticking')
	(stopScript: 'make the specified script stop running')
	(turn: 'turn by the specified amount')
	(wearCostumeOf: 'wear a costume resembling that of another player')
	(wrap 'if I have just run into a boundary, reappear at the corresponding point on the opposite side')
	
 
		) do: [:pair | helpDict at: pair first put: pair second].

	ScriptingSystem scriptHelp: helpDict"

	| aDoIt |
	aDoIt _ StandardScriptingSystem firstCommentAt: #initializeScriptHelp.
	Compiler evaluate: aDoIt

"ScriptingSystem initializeScriptHelp"

"(     basicType beNotZero:   categories changeScript:toStatus: changeVariableType checkCostume choosePenColor: choosePenSize chooseSlotTypeFor: chooseUserSlot color color:sees: colorUnder commandPhraseFor:inViewer: compileAccessorsFor: compileInstVarAccessorsFor: convertdc0:dcc0: copyStateFrom: copyUniClass costume costume: costumeRespondingTo: costumeSlotNamesAndTypesForBank: costumes costumesDo: createNewCard defaultLabelForInspector defaultPenColor defaultPenSize  dummy externalName  forgetOtherCostumes  getAmount getAngle getBorderColor getBorderWidth getBottom getColor getColorUnder getCursor getHeading getHeadingUnrounded getHeight getInfo getIsUnderMouse getLeft getLeftRight getMouseX getMouseY getName getPenColor getPenDown getPenSize getRight getRotationStyle getScaleFactor getSpeed getTop getUpDown getValueAtCursor getValueFromCostume: getWidth getX getY     grabPlayerIn: hasCostumeOfClass: hasScriptInvoking:ofPlayer: hasScriptReferencing:ofPlayer: headDown headLeft headRight headUp  infoFor: initialTypeForSlotNamed: initialValueForSlotOfType: initializeCostumesFrom: initiatePainting instantiatedUserScriptsDo: isFlagshipForClass justClonedFrom: knownSketchCostumeWithSameFormAs: lastEvent   liftPen  lowerPen makeBounceSound: maxPartsBankNumber maxScriptsBankNumber   newCostume  noteDeletionOf:fromWorld: okayToDestroyScriptNamed: okayToRemoveSlotNamed: owningPlayer  penColor: personalSlotNamesAndTypesForBank: phraseSpecFor: presenter  printOn: rawCostume: rememberCostume: removeSlotNamed: renameSlot: renameTo: renderedCostume: renderedCostumeRespondsTo: revealPlayerIn: revertToUnscriptedPlayerIfAppropriate runAllClosingScripts runAllOpeningScripts runAllTickingScripts scriptEditorFor: scriptEvaluatorFor:phrase: scriptInstantiationForSelector: scriptPerformer seesColor: sendMessageToCostume: sendMessageToCostume:with: setBorderColor: setBorderWidth: setBottom: setColor: setCostume: setCostumeSlot:toValue: setCursor: setHeading: setHeight: setLeft: setName: setPenColor: setPenDown: setPenSize: setRight: setRotationStyle: setScaleFactor: setTop: setValueAtCursor: setWidth: setX: setY:  slotInfo slotNames slotNamesAndTypesForViewerBank: slotPhraseFor:inViewer: standardCommandsForBank: standardSlotsForBank: standardWorldSlotsForBank: startRunning startRunningScripts  step stopProgramatically stopRunning  tearOffFancyWatcherFor: tearOffTileForSelf tearOffWatcherFor: thumbnailMenuEvt:forMorph: tileForArgType: tileForArgType:inViewer: tilePhraseSpecsForPlayerCategory: tilePhrasesForCategory:inViewer: tilePhrasesSpecsForCategory: tileReferringToSelf tileScriptCommands tileScriptCommandsForBank:  typeForSlot: typedCommandsForBank: unusedScriptName updateAllViewers valueOfType:from:  wearCostumeOfClass: wearCostumeOfName: wearSketchCostumeResembling: width  "