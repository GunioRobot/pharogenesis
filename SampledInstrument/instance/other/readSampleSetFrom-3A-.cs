readSampleSetFrom: dirName
	"Answer a collection of sounds read from AIFF files in the given directory and sorted in ascending pitch order."

	| all dir fullName snd |
	all _ SortedCollection sortBlock: [:s1 :s2 | s1 pitch < s2 pitch].
	dir _ FileDirectory default on: dirName.
	dir fileNames do: [:n |
		fullName _ dir fullNameFor: n.
		Utilities
			informUser: 'Reading AIFF file ', n
			during:
				[snd _ LoopedSampledSound new
					fromAIFFFileNamed: fullName
					mergeIfStereo: true].
		all add: snd].
	^ all asArray
