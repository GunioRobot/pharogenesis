resumePlaying
	"Resume playing. Start over if done."

	done ifTrue: [self reset].
	super resumePlaying.
