actOnClickFor: textMorph
	"I represent a link to either a SqueakPage in a BookMorph, or a regular url"

	| book |
	((url endsWith: '.bo') or: [url endsWith: '.sp']) ifFalse: [
		^ super actOnClickFor: textMorph].
	book _ textMorph ownerThatIsA: BookMorph.
	book ifNotNil: [book goToPageUrl: url].
	"later handle case of page being in another book, not this one"
	^ true