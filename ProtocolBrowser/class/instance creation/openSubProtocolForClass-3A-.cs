openSubProtocolForClass: aClass 
	"Create and schedule a browser for the entire protocol of the class."
	"ProtocolBrowser openSubProtocolForClass: ProtocolBrowser."
	| aPBrowser label |
	aPBrowser := ProtocolBrowser new onSubProtocolOf: aClass.
	label := 'Sub-protocol of: ', aClass name.
	self open: aPBrowser name: label