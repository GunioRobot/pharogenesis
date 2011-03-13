testCrTabs
	"self debug: #testCrTabs"
	
	| stream |
	stream := WriteStream on: 'stream'.
	stream crtab: 2.
	self assert: (stream contents last: 3) = (String with: Character cr with: Character tab with: Character tab)