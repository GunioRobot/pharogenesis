openFullProtocolForClass: aClass 
	"Create and schedule a browser for the entire protocol of the class."
	"ProtocolBrowser openFullProtocolForClass: ProtocolBrowser."
	| aPBrowser label |
	aPBrowser := ProtocolBrowser new on: aClass.
	label := 'Entire protocol of: ', aClass name.
	self open: aPBrowser name: label