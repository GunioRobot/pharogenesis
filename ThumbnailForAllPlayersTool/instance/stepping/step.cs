step
	"periodic action"

	| aMorph |
	((aMorph _ objectToView costume) notNil and: [aMorph isInWorld]) ifTrue:
		[super step]  "don't bother changing my readout to blank when/if object disappears"