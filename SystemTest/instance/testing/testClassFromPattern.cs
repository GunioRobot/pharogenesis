testClassFromPattern
	"self debug: #testClassFromPattern"

	self assert: (SystemNavigation default
		classFromPattern: 'TComposingD' withCaption: '') = TComposingDescription