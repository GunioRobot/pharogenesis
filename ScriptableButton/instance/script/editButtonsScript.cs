editButtonsScript
	"The user has touched my Scriptor halo-handle.  Bring up a Scriptor on the script of the button."

	| cardsPasteUp cardsPlayer anEditor |
	cardsPasteUp _ self pasteUpMorph.
	(cardsPlayer _ cardsPasteUp assuredPlayer) assureUniClass.
	anEditor _ scriptSelector
			ifNil:
				[scriptSelector _ cardsPasteUp scriptSelectorToTriggerFor: self.
				cardsPlayer newScriptEditorFor: scriptSelector usingPhraseTile: nil]
			ifNotNil:
				[(cardsPlayer class selectors includes: scriptSelector)
					ifTrue:
						[cardsPlayer scriptEditorFor: scriptSelector]
					ifFalse:
						["Method somehow got removed; I guess we start aftresh"
						scriptSelector _ nil.
						^ self editButtonsScript]].
	self currentHand attachMorph: anEditor.
