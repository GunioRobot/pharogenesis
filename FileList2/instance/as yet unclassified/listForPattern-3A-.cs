listForPattern: pat
	"Make the list be those file names which match the pattern."

	| sizePad newList |
	directory ifNil: [^#()].
	newList _ directory entries select: [:entry | fileSelectionBlock value: entry value: pat].
	newList _ newList asSortedCollection: self sortBlock.
	sizePad _ (newList inject: 0 into: [:mx :entry | mx max: (entry at: 5)])
					asStringWithCommas size - 1.
	newList _ newList collect: [ :e | self fileNameFormattedFrom: e sizePad: sizePad ].
	^ newList asArray