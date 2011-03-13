spawnProtocol
	| aClassOrMetaclass |
	"Create and schedule a new protocol browser on the currently selected class or meta."
	(aClassOrMetaclass _ self selectedClassOrMetaClass) ifNotNil:
       	[ProtocolBrowser openSubProtocolForClass: aClassOrMetaclass]