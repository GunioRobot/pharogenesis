printSpaceAnalysis		"Smalltalk garbageCollect; printSpaceAnalysis"
	| f name space words scale count |
	f _ FileStream newFileNamed: 'STspace.text'.
	f timeStamp.
	self allClassesDo:
		[:cl | name _ cl name.
		Sensor redButtonPressed ifTrue: [Transcript cr; show: name].
		space _ cl == Character ifTrue: [#(0 0)] ifFalse: [cl space].
		count _ cl instanceCount.
		f print: name; tab;
			print: space first; tab;
			print: space last; tab;
			print: count; tab.
		words _ (cl instSize+2)*count.
		cl isVariable ifTrue:
				[scale _ cl isBytes ifTrue: [2] ifFalse: [1].
				cl allInstancesDo: [:x | words _ words + (x size//scale)]].
		f print: words; cr].
	f close