deleteControls
	"If the receiver has an element answering to the name 'Page Controls', delete it"

	| controls |
	(controls _ self findSubmorphThat: [:m | m externalName = 'Page Controls'] ifAbsent: [nil]) ifNotNil:
		[controls delete.
		self changed]