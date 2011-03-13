navigationKey: event
	"Check for tab key activity and change focus as appropriate.
	Check for menu key to do popup."

	(self tabKey: event) ifTrue: [^true].
	(event keyCharacter = Character escape and: [
			event anyModifierKeyPressed]) ifTrue: [
		self yellowButtonActivity: false.
		^true].
	self window ifNotNilDo: [:win |
		(win handlesKeyboard: event) ifTrue: [
			(win keyStroke: event) ifTrue: [^true]]].
	^false