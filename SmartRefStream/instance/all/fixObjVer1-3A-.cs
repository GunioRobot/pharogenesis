fixObjVer1: className
	"Temporary bug fix.  Old obj files have no structure entry for Obj and other HyperSqueak classes that have unique instances.  Add the data to structures.  Will also have to read in ObjConvertDec96.st  "

	| data ind |
	Smalltalk at: #Obj ifAbsent: [^ self].	"non HyperSqueak"

	data _ #( "Alias" ()  "BooleanObj" ()  "FastObj" ('blitter' 'fastVelocity ') 
		"Folder" ('contentsDictionary') "NumberObj" () 
		"Obj" (0 'dependents' 'objectContainedIn' 'workingsBackToFront' 'workingsDictionary' 'contents' 'costumes' 'currentCostume' 'parameters' 'canvas' 'canvasValid' 'layoutRectangle' 'windowBounds' 'flags' 'velocity' 'type' 'heading' 'speed' 'pen' )
		"StringObj" ()  "TextObj" ('prevTextFrame' 'nextTextFrame' 'suppressDisplay')).

	ind _ #(Alias BooleanObj FastObj Folder NumberObj Obj StringObj TextObj) indexOf: className.
	ind = 0 ifTrue: [^ self].
	structures at: className put: 
		(className == #Obj
				ifTrue: [data at: ind]
				ifFalse: [(data at: 6 "Obj"), (data at: ind)]).
	self verifyStructure
