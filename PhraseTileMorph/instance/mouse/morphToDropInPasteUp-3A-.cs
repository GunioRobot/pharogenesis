morphToDropInPasteUp: aPasteUp
	"Answer the morph to drop in aPasteUp, given that the receiver is the putative droppee"

	| actualObject itsSelector aScriptor pos aWatcher op |

	((actualObject _ self actualObject) isNil or: [actualObject costume isInWorld not]) ifTrue: [^ self].
	self isCommand ifFalse:  "Can't expand to a scriptor, but maybe launch a watcher..."
		[^ (Preferences dropProducesWatcher and: [(#(unknown command) includes: self resultType) not] and:
			[(op _ self operatorTile operatorOrExpression) notNil] and: [op numArgs = 0] and: [(Vocabulary gettersForbiddenFromWatchers includes: op) not])
			ifTrue:
				[aWatcher _ self associatedPlayer fancyWatcherFor: op.
				aWatcher position: self position]
			ifFalse:
				[self]].

	self justGrabbedFromViewer ifFalse: [^ self].
	actualObject assureUniClass.
	itsSelector _ self userScriptSelector.
	pos _ self position.
	aScriptor _ itsSelector isEmptyOrNil
		ifFalse:
			[actualObject scriptEditorFor: itsSelector]
		ifTrue:
			["It's a system-defined selector; construct an anonymous scriptor around it"
			actualObject newScriptorAround: self].
	aScriptor ifNil:[^self].
	(self hasOwner: aScriptor) ifTrue:[
		aScriptor fullBounds. "force layout"
		aScriptor position: pos - self position.
	] ifFalse:[
		aScriptor position: self position.
	].
	^ aScriptor