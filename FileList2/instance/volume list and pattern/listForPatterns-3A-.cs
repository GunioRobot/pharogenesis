listForPatterns: anArray
	"Make the list be those file names which match the patterns."

	| sizePad newList |
	directory ifNil: [^#()].
	(fileSelectionBlock isKindOf: MessageSend) ifTrue: [
		fileSelectionBlock arguments: {directory entries}.
		newList _ fileSelectionBlock value.
		fileSelectionBlock arguments: #().
	] ifFalse: [
		newList _ Set new.
		anArray do: [ :pat |
			newList addAll: (directory entries select: [:entry | fileSelectionBlock value: entry value: pat]) ].
	].
	newList _ newList asSortedCollection: self sortBlock.
	sizePad _ (newList inject: 0 into: [:mx :entry | mx max: (entry at: 5)])
					asStringWithCommas size - 1.
	newList _ newList collect: [ :e | self fileNameFormattedFrom: e sizePad: sizePad ].
	^ newList asArray