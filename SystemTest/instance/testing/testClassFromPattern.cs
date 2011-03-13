testClassFromPattern
	"self debug: #testClassFromPattern"

	self assert: (Utilities classFromPattern: 'TCompilingB' withCaption: '') = TCompilingBehavior