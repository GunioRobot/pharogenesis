keyStroke: evt
	"Handle a keystroke. Deal with navigation keys also."
	
	| view |
	(editView scrollByKeyboard: evt) ifTrue: [^self].
	(acceptOnCR not and: [evt keyCharacter = Character cr])
		ifFalse: [(editView navigationKey: evt) ifTrue: [^self]].
	self editor model: editView model.  "For evaluateSelection"
	view := editView.  "Copy into temp for case of a self-mutating doit"
	self editView enabled
		ifTrue: [(acceptOnCR and: [evt keyCharacter = Character cr])
					ifTrue: [^ self editor accept].
				super keyStroke: evt]
		ifFalse: ["alllow some commands"
				self eventHandler ifNotNil:
					[self eventHandler keyStroke: evt fromMorph: self].
				self handleInteraction: [editor handleDisabledKey: evt.]].
	view scrollSelectionIntoView