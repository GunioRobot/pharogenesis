superiors
	| result |
	result := OrderedCollection new.
	self superiorsDo: [:ea | result add: ea].
	^ result asArray reversed