activationKeys
	"Return the keyframes on which the receiver morph becomes visible"
	^self visibleData keys select:[:key| self visibleAtFrame: key]