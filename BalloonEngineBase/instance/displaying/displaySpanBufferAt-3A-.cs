displaySpanBufferAt: y
	"Display the span buffer at the current scan line."
	| targetX0 targetX1 targetY |
	self inline: false.
	"self aaLevelGet > 1 ifTrue:[self adjustAALevel]."
	targetX0 _ self spanStartGet >> self aaShiftGet.
	targetX0 < self clipMinXGet ifTrue:[targetX0 _ self clipMinXGet].
	targetX1 _ (self spanEndGet + self aaLevelGet - 1) >> self aaShiftGet.
	targetX1 > self clipMaxXGet ifTrue:[targetX1 _ self clipMaxXGet].
	targetY _ y >> self aaShiftGet.
	(targetY < self clipMinYGet or:[targetY >= self clipMaxYGet or:[
		targetX1 < self clipMinXGet or:[targetX0 >= self clipMaxXGet]]]) ifTrue:[^0].
	self copyBitsFrom: targetX0 to: targetX1 at: targetY.