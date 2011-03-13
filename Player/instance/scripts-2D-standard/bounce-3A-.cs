bounce: soundName
	"If the receiver's current bounds obtrude beyond the bounds of its container, then 'bounce' it back within the container, and make the indicated sound while doing so"

	| box bounced aCostume |
	(aCostume _ self costume) ifNil: [^ self].
	(aCostume owner == nil or: [aCostume owner isHandMorph]) ifTrue: [^ self].
	box _ aCostume owner bounds.
	bounced _ false.
	(aCostume left < box left)			ifTrue: [self headRight. bounced _ true].
	(aCostume right > box right)		ifTrue: [self headLeft. bounced _ true].
	(aCostume top < box top)			ifTrue: [self headDown. bounced _ true].
	(aCostume bottom > box bottom)	ifTrue: [self headUp. bounced _ true].
	bounced ifTrue: [^ self makeBounceSound: soundName].
