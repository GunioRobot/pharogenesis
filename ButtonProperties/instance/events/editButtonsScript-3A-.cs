editButtonsScript: evt
	"The user has touched my Scriptor halo-handle.  Bring up a Scriptor on the script of the button."

	| cardsPasteUp cardsPlayer anEditor scriptSelector |

	cardsPasteUp _ self pasteUpMorph.
	(cardsPlayer _ cardsPasteUp assuredPlayer) assureUniClass.
	scriptSelector _ self figureOutScriptSelector.
	scriptSelector ifNil: [
		scriptSelector _ cardsPasteUp scriptSelectorToTriggerFor: self.
		anEditor _ cardsPlayer newTextualScriptorFor: scriptSelector.
		evt hand attachMorph: anEditor.
		^self
	].

	(cardsPlayer class selectors includes: scriptSelector) ifTrue: [
		anEditor _ cardsPlayer scriptEditorFor: scriptSelector.
		evt hand attachMorph: anEditor.
		^self
	].
	"Method somehow got removed; I guess we start aftresh"
	scriptSelector _ nil.
	^ self editButtonsScript