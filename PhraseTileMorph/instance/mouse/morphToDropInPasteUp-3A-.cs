morphToDropInPasteUp: aPasteUp
	"Answer the morph to drop in aPasteUp, given that the receiver is the putative droppee"

	| actualObject itsSelector aScriptor adjustment handy |

	self isCommand ifFalse: [^ self].
	(actualObject _ self actualObject) ifNil: [^ self].
	self justGrabbedFromViewer ifFalse: [^ self].
	actualObject assureUniClass.
	itsSelector _ self userScriptSelector.
	aScriptor _ itsSelector isEmptyOrNil
		ifFalse:
			[adjustment _ 0@0.
			actualObject scriptEditorFor: itsSelector]
		ifTrue:
			["It's a system-defined selector; construct an anonymous scriptor around it"
			adjustment _ 60 @ 20.
			actualObject newScriptorAround: self].

	handy _ aPasteUp primaryHand.
	aScriptor ifNotNil: [aScriptor position: handy position - adjustment].
	^ aScriptor ifNil: [self]