addScaleHandle: haloSpec
	target isFlexMorph ifTrue: 
		[(self addHandle: haloSpec
				on: #mouseDown send: #startScale:with: to: self)
				on: #mouseStillDown send: #doScale:with: to: self].
	"This or addGrowHandle:, but not both, will prevail at any one time"
