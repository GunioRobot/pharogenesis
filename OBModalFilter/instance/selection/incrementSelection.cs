incrementSelection
	selection _ selection + 1.
	(selection > metaNode edges size) ifTrue: [selection _ 1].