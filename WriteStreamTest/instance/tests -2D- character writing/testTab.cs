testTab
	"self debug: #testTab"
	
	| stream |
	stream := WriteStream on: 'stream'.
	stream tab.
	self assert: (stream contents last) = Character tab