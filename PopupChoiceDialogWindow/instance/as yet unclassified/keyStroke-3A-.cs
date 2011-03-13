keyStroke: anEvent
	"Look for a matching item?"

	(super keyStroke: anEvent) ifTrue: [^true].
	anEvent keyCharacter = Character backspace
		ifTrue: [self prefixFilter ifNotEmpty: [self prefixFilter: self prefixFilter allButLast]].
	anEvent keyCharacter = Character arrowUp ifTrue: [self selectLastEnabledItem. ^true].
	anEvent keyCharacter = Character arrowDown ifTrue: [self selectFirstEnabledItem. ^true].
	anEvent keyCharacter = Character arrowLeft ifTrue: [self switchToPreviousColumn. ^true].
	anEvent keyCharacter = Character arrowRight ifTrue: [self switchToNextColumn. ^true].
	(anEvent keyCharacter ~= Character cr and: [
		anEvent keyCharacter < Character space]) ifTrue: [^false]. "ignore pageup/down etc."
	(anEvent keyCharacter = Character space or: [
			anEvent keyCharacter = Character cr]) ifTrue: [
		self choiceMenus do: [:embeddedMenu | 
			embeddedMenu selectedItem ifNotNilDo: [:item |
				item invokeWithEvent: anEvent.
				^true]]].
	anEvent keyCharacter = Character backspace ifFalse: [
		self prefixFilter: self prefixFilter, anEvent keyCharacter asString].
	^false