processUnhandledPage: newSource
	"offer to save it to a file"
	| fileName file |
	self status: 'sittin'.

	(newSource url toText endsWith: '.pr') ifTrue: [
		(self confirm: 'Looks like a Squeak project - do you want to load it as such?') ifTrue: [
			^ProjectLoading thumbnailFromUrl: newSource url toText
		].
	].

	(self confirm: 'unkown content-type ', newSource contentType,'--
Would you like to save to a file?') ifFalse: [ ^false ].

	fileName _ ''.
	[
		fileName _ FillInTheBlank request: 'file to save in' initialAnswer: fileName.
		fileName isEmpty ifTrue: [ ^self ].
		file _ FileStream fileNamed: fileName.
		file == nil
	] whileTrue.

	file reset.
	file binary.
	file nextPutAll: newSource content.
	file close.
	^true