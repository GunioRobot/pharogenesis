printSpaceAnalysis: threshold on: fileName
	"SpaceTally new printSpaceAnalysis: 1000 on: 'STspace.text1'"

	"sd-This method should be rewrote to be more coherent within the rest of the class 
	ie using preAllocate and spaceForInstanceOf:"

	"If threshold > 0, then only those classes with more than that number
	of instances will be shown, and they will be sorted by total instance space.
	If threshold = 0, then all classes will appear, sorted by name."

	| f codeSpace instCount instSpace totalCodeSpace totalInstCount totalInstSpace eltSize n totalPercent percent |
	Smalltalk garbageCollect.
	totalCodeSpace _ totalInstCount _ totalInstSpace _ n _ 0.
	results _ OrderedCollection new: Smalltalk classNames size.
'Taking statistics...'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: Smalltalk classNames size
	during: [:bar |
	Smalltalk allClassesDo:
		[:cl | codeSpace _ cl spaceUsed.
		bar value: (n _ n+1).
		Smalltalk garbageCollectMost.
		instCount _ cl instanceCount.
		instSpace _ (cl indexIfCompact > 0 ifTrue: [4] ifFalse: [8])*instCount. "Object headers"
		cl isVariable
			ifTrue: [eltSize _ cl isBytes ifTrue: [1] ifFalse: [4].
					cl allInstancesDo: [:x | instSpace _ instSpace + (x basicSize*eltSize)]]
			ifFalse: [instSpace _ instSpace + (cl instSize*instCount*4)].
		results add: (SpaceTallyItem analyzedClassName: cl name codeSize: codeSpace instanceCount:  instCount spaceForInstances: instSpace).
		totalCodeSpace _ totalCodeSpace + codeSpace.
		totalInstCount _ totalInstCount + instCount.
		totalInstSpace _ totalInstSpace + instSpace]].
	totalPercent _ 0.0.

	f _ FileStream newFileNamed: fileName.
	f timeStamp.
	f nextPutAll: ('Class' padded: #right to: 30 with: $ );
			nextPutAll: ('code space' padded: #left to: 12 with: $ );
			nextPutAll: ('# instances' padded: #left to: 12 with: $ );
			nextPutAll: ('inst space' padded: #left to: 12 with: $ );
			nextPutAll: ('percent' padded: #left to: 8 with: $ ); cr.

	threshold > 0 ifTrue:
		["If inst count threshold > 0, then sort by space"
		results _ (results select: [:s | s instanceCount >= threshold or: [s spaceForInstances > (totalInstSpace // 500)]])
				asSortedCollection: [:s :s2 | s spaceForInstances > s2 spaceForInstances]].

	results do:
		[:s | f nextPutAll: (s analyzedClassName padded: #right to: 30 with: $ );
			nextPutAll: (s codeSize printString padded: #left to: 12 with: $ );
			nextPutAll: (s instanceCount printString padded: #left to: 12 with: $ );
			nextPutAll: (s spaceForInstances printString padded: #left to: 14 with: $ ).
		percent _ s spaceForInstances*100.0/totalInstSpace roundTo: 0.1.
		totalPercent _ totalPercent + percent.
		percent >= 0.1 ifTrue:
			[f nextPutAll: (percent printString padded: #left to: 8 with: $ )].
		f cr].

	f cr; nextPutAll: ('Total' padded: #right to: 30 with: $ );
		nextPutAll: (totalCodeSpace printString padded: #left to: 12 with: $ );
		nextPutAll: (totalInstCount printString padded: #left to: 12 with: $ );
		nextPutAll: (totalInstSpace printString padded: #left to: 14 with: $ );
		nextPutAll: ((totalPercent roundTo: 0.1) printString padded: #left to: 8 with: $ ).
	f close