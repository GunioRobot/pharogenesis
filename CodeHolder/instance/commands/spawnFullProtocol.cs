spawnFullProtocol
	"Create and schedule a new protocol browser on the currently selected class or meta."

	| aClassOrMetaclass |
	(aClassOrMetaclass := self selectedClassOrMetaClass) ifNotNil:
       	[ProtocolBrowser openFullProtocolForClass: aClassOrMetaclass]