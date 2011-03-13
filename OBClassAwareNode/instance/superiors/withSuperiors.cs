withSuperiors
	| result |
	result := OrderedCollection new.
	result add: self.
	self superiorsDo: [:ea | result add: ea].
	^ result asArray reversed