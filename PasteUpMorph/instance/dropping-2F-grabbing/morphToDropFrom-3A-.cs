morphToDropFrom: aMorph
	"Presently only in service for features in the tile-scripting system that allow a different object from the one being carried to be dropped"

	| itsSelector aScriptor adjustment anEditor actualObject aUserScript |
	self expandPhrasesToScripts ifFalse: [^ aMorph].

	(aMorph hasProperty: #newAnonymousScript) ifTrue: [^ self emptyAnonymousScriptorFrom: aMorph].
	(aMorph isKindOf: PhraseTileMorph) ifFalse: [^ aMorph].

	(actualObject _ aMorph actualObject) ifNil: [^ aMorph].

	aScriptor _ (itsSelector _ aMorph userScriptSelector) size > 0
		ifTrue:
			[actualObject isFlagshipForClass
				ifFalse:
					["We can set the status for our instantiation of this script, but cannot allow script editing"
					anEditor _ actualObject scriptEvaluatorFor: itsSelector phrase: aMorph.
					adjustment _ 50 @ 40.
					anEditor]
				ifTrue:
					["old note: ambiguous case: if there's a script editor on the world, drop down a button, else drop down the script editor"
					aUserScript _ actualObject class userScriptForPlayer: actualObject selector: itsSelector.
					aUserScript isTextuallyCoded
						ifTrue: [^ self scriptorForTextualScript: itsSelector ofPlayer: actualObject].
					((anEditor _ actualObject scriptEditorFor: itsSelector) isInWorld and:
							[anEditor owner == self])
						ifFalse:
							[adjustment _ 50 @ 30.
							anEditor]
						ifTrue:
							[adjustment _ 60 @ 20.
							actualObject anonymousScriptEditorFor: aMorph]]]

		ifFalse:   "It's a system-defined selector; construct an anonymous scriptor around it"
			[adjustment _ 60 @ 20.
			actualObject anonymousScriptEditorFor: aMorph].

	aScriptor position: (self primaryHand position - adjustment).
	^ aScriptor