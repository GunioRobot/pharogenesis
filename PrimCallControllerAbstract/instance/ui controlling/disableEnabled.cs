disableEnabled
	"Disables these external prim calls, which are formerly enabled by self."
	self treatedMethods
		keysAndValuesDo: [:mRef :status | status == #enabled
				ifTrue: [self disableCallIn: mRef]]