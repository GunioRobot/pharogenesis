parseFileNamed: aString
	"VRMLNodeParser parseFileNamed:'C:\WDI-Website\Link 3D Models\08-17-99\vrml\test.wrl'"
	"MessageTally spyOn:[
		VRMLNodeParser 
			parseFileNamed:'C:\WDI-Website\Link 3D Models\08-17-99\vrml\linkvrml97.WRL']"
	| stream result |
	stream := FileStream readOnlyFileNamed: aString.
	stream size < 500000 "cache in memory"
		ifTrue:[result _ self parse: (ReadStream on: stream contentsOfEntireFile) url: stream name]
		ifFalse:[result := self parse: stream].
	stream close.
	^result