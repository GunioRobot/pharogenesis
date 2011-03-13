removeEventTrigger: aSymbol
	"Remove all the event registrations for my Player that are triggered by aSymbol.
	User custom events are triggered at the World,
	while system custom events are triggered on individual Morphs."

	| player |
	(player := self player) ifNil: [ ^self ].
	self removeEventTrigger: aSymbol for: player.
	self currentWorld removeEventTrigger: aSymbol for: player.