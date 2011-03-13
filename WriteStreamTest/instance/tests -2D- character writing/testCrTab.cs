testCrTab
	"self debug: #testCrTab"
	
	| stream |
	stream := WriteStream on: 'stream'.
	stream crtab.
	self assert: (stream contents last: 2) = (String with: Character cr with: Character tab)