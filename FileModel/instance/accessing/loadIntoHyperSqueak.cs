loadIntoHyperSqueak
	"Load the currently-selected file in as a HyperSqueak save-file.  8/12/96 sw"

	| ff this save |
	Smalltalk hyperSqueakPresent ifFalse:
		[^ self inform: 'Sorry, HyperSqueak is not present in the current system.'].

	ff _ ReferenceStream fileNamed: self fullName.
	save _ Preferences logUserScripts.
	Preferences startLoggingUserScripts.  "for incoming buttons"
	[this _ ff next.
		this class == SmallInteger ifTrue: ["version number"].
		this class == Array ifTrue:
			[(this at: 1) = 'class structure' ifTrue:
				["Verify the shapes of all the classes"
				(DataStream incomingObjectsClass  acceptStructures: this) ifFalse:
					[^ ff close]]].	"An error occurred"
		this class name == DataStream incomingObjectsClass name ifTrue:
			["My HyperSqueak objects were installed during 'next'"].
		ff atEnd] whileFalse.		 
	ff close.
	save ifFalse: [Preferences stopLoggingUserScripts].