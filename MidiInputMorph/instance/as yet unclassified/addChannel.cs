addChannel
	"Add a set of controls for another channel. Prompt the user for the channel number."

	| menu existingChannels newChannel |
	menu _ CustomMenu new.
	existingChannels _ Set new.
	1 to: 16 do: [:ch | (instrumentSelector at: ch) ifNotNil: [existingChannels add: ch]].
	1 to: 16 do: [:ch |
		(existingChannels includes: ch) ifFalse: [
			menu add: ch printString action: ch]].
	newChannel _ menu startUp.
	newChannel ifNotNil: [self addChannelControlsFor: newChannel].
