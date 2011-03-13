= aCollection
	self == aCollection ifTrue: [^ true].
	self species == aCollection species ifFalse: [^ false].
	aCollection size = self size ifFalse: [^ false].
	aCollection do: [:each | (self includes: each) ifFalse: [^ false]].
	^ true