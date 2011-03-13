sendsToSuper
	"Answer whether the receiver sends any message to super."

	^ (self scanFor: 16r85) or: [self scanFor: 16r86]