colorForInsets
	"My submorphs use the surrounding color"
	| aColor |
	(aColor _ owner color) ifKindOf: Color thenDo: [:c | ^ aColor].
	"This workaround relates to cases where the scrollPane's color is not a true color but rather an InfiniteForm, which is not happy to be returned here"
	^ Color white