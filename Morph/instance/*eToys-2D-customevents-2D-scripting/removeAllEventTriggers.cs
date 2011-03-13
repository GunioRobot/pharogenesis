removeAllEventTriggers
	"Remove all the event registrations for my Player.
	User custom events are triggered at the World,
	while system custom events are triggered on individual Morphs."

	| player |
	(player _ self player) ifNil: [ ^self ].
	self removeAllEventTriggersFor: player.
	self currentWorld removeAllEventTriggersFor: player.