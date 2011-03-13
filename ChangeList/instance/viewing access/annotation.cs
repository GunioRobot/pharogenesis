annotation
	"Answer the string to be shown in an annotation pane.  Make plain that the annotation is associated with the current in-image version of the code, not of the selected disk-based version."

	| annot |

	annot _ super annotation.
	^ annot asString = '------'
		ifTrue:
			[annot]
		ifFalse:
			['current version: ', annot]