enableDisabled
	"Enables these external prim calls, which are formerly disabled by self."
	self treatedMethods
		keysAndValuesDo: [:mRef :status | status == #disabled
				ifTrue: [self enableCallIn: mRef]]