readSampleSetFrom: dirName
	"Answer a collection of sounds read from AIFF files in the given directory and sorted in ascending pitch order."

	| all dir fullName snd |
	all := SortedCollection sortBlock: [:s1 :s2 | s1 pitch < s2 pitch].
	dir := FileDirectory default on: dirName.
	dir fileNames do: [:n |
		fullName := dir fullNameFor: n.
		Utilities
			informUser: 'Reading AIFF file ', n
			during:
				[snd := LoopedSampledSound new
					fromAIFFFileNamed: fullName
					mergeIfStereo: true].
		all add: snd].
	^ all asArray
