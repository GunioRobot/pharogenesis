destroy
	"Stop listening."

	| sock |
	listener terminate.
	socket destroy.
	[queue size > 0] whileTrue: [(sock := queue next) notNil ifTrue: [sock destroy]]