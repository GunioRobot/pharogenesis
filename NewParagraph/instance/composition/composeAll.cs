composeAll
	text string isOctetString ifTrue: [
		^ self composeLinesFrom: firstCharacterIndex to: text size delta: 0
			into: OrderedCollection new priorLines: Array new atY: container top.
	].

	^ self multiComposeLinesFrom: firstCharacterIndex to: text size delta: 0
		into: OrderedCollection new priorLines: Array new atY: container top.
