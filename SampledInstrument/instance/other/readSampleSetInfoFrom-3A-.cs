readSampleSetInfoFrom: dirName
	"MessageTally spyOn: [SampledInstrument new readSampleSetFrom: 'Tosh:Desktop Folder:AAA Squeak2.0 Beta:Organ Samples:Flute8'] timeToRun"

	| all dir fullName info |
	all _ OrderedCollection new.
	dir _ FileDirectory default on: dirName.
	dir fileNames do: [:n |
		fullName _ dir fullNameFor: n.
		info _ AIFFFileReader new readFromFile: fullName
			mergeIfStereo: false
			skipDataChunk: true.
		all add: n -> info].
	^ all
