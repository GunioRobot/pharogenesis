readCollagePic
	"Read in the Imagineering collage for the demo."
	| f |
	f _ FileStream oldFileNamed: 'imagicollage.morph'.
	self formDictionary at: 'CollagePic' put: f fileInObjectAndCode form
