bounce: soundName

	| box bounced |
	costume ifNil: [^ self].
	(costume owner == nil or: [costume owner isHandMorph]) ifTrue: [^ self].
	box _ costume owner bounds.
	bounced _ false.
	(costume left < box left)			ifTrue: [self headRight. bounced _ true].
	(costume right > box right)		ifTrue: [self headLeft. bounced _ true].
	(costume top < box top)			ifTrue: [self headDown. bounced _ true].
	(costume bottom > box bottom)	ifTrue: [self headUp. bounced _ true].
	bounced ifTrue: [^ self makeBounceSound: soundName].
