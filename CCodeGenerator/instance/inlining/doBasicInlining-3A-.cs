doBasicInlining: inlineFlag
	"Inline the bodies of all methods that are suitable for inlining.
	This method does only the basic inlining suitable for both the core VM and plugins - no bytecode inlining etc"

	| pass progress |
	self collectInlineList.
	pass _ 0.
	progress _ true.
	[progress] whileTrue: [
		"repeatedly attempt to inline methods until no further progress is made"
		progress _ false.
		('Inlining pass ', (pass _ pass + 1) printString, '...')
			displayProgressAt: Sensor cursorPoint
			from: 0 to: methods size
			during: [:bar |
				methods doWithIndex: [:m :i |
					bar value: i.
					(m tryToInlineMethodsIn: self)
						ifTrue: [progress _ true]]]].

