readSampleSetInfoFrom: dirName
	"MessageTally spyOn: [SampledInstrument new readSampleSetFrom: 'Tosh:Desktop Folder:AAA Squeak2.0 Beta:Organ Samples:Flute8'] timeToRun"

	| all dir fullName info |
	all := OrderedCollection new.
	dir := FileDirectory default on: dirName.
	dir fileNames do: [:n |
		fullName := dir fullNameFor: n.
		info := AIFFFileReader new readFromFile: fullName
			mergeIfStereo: false
			skipDataChunk: true.
		all add: n -> info].
	^ all
