printSpaceAnalysis: threshold on: aStream
	"SpaceTally new printSpaceAnalysis: 1 on:(FileStream forceNewFileNamed: 'STspace.text')"

	"sd-This method should be rewrote to be more coherent within the rest of the class 
	ie using preAllocate and spaceForInstanceOf:"

	"If threshold > 0, then only those classes with more than that number
	of instances will be shown, and they will be sorted by total instance space.
	If threshold = 0, then all classes will appear, sorted by name."

	| codeSpace instCount instSpace totalCodeSpace totalInstCount totalInstSpace eltSize n totalPercent percent |
	Smalltalk garbageCollect.
	totalCodeSpace := totalInstCount := totalInstSpace := n := 0.
	results := OrderedCollection new: Smalltalk classNames size.
	'Taking statistics...'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: Smalltalk classNames size
		during: [:bar |
			"stephane.ducasse: clearly a hack because MethodContext allInstances fails right now"
		((Smalltalk allClasses)
			reject: [:each | each name = 'MethodContext']) do:
			[:cl | codeSpace := cl spaceUsed.
			bar value: (n := n+1).
			Smalltalk garbageCollectMost.
			instCount := cl instanceCount.
			instSpace := (cl indexIfCompact > 0 ifTrue: [4] ifFalse: [8])*instCount. "Object headers"
			cl isVariable
				ifTrue: [eltSize := cl isBytes ifTrue: [1] ifFalse: [4].
						cl allInstancesDo: [:x | instSpace := instSpace + (x basicSize*eltSize)]]
			ifFalse: [instSpace := instSpace + (cl instSize*instCount*4)].
			results add: (SpaceTallyItem analyzedClassName: cl name codeSize: codeSpace instanceCount:  instCount spaceForInstances: instSpace).
			totalCodeSpace := totalCodeSpace + codeSpace.
			totalInstCount := totalInstCount + instCount.
			totalInstSpace := totalInstSpace + instSpace]].
		totalPercent := 0.0.

	aStream timeStamp.
	aStream
		nextPutAll: ('Class' padded: #right to: 30 with: $ );
		nextPutAll: ('code space' padded: #left to: 12 with: $ );
		nextPutAll: ('# instances' padded: #left to: 12 with: $ );
		nextPutAll: ('inst space' padded: #left to: 12 with: $ );
		nextPutAll: ('percent' padded: #left to: 8 with: $ ); cr.

	threshold > 0 ifTrue: [
		"If inst count threshold > 0, then sort by space"
		results := (results select: [:s | s instanceCount >= threshold or: [s spaceForInstances > (totalInstSpace // 500)]])
			asSortedCollection: [:s :s2 | s spaceForInstances > s2 spaceForInstances]].

	results do: [:s |
		aStream
			nextPutAll: (s analyzedClassName padded: #right to: 30 with: $ );
			nextPutAll: (s codeSize printString padded: #left to: 12 with: $ );
			nextPutAll: (s instanceCount printString padded: #left to: 12 with: $ );
			nextPutAll: (s spaceForInstances printString padded: #left to: 14 with: $ ).
		percent := s spaceForInstances*100.0/totalInstSpace roundTo: 0.1.
		totalPercent := totalPercent + percent.
		percent >= 0.1 ifTrue: [
			aStream nextPutAll: (percent printString padded: #left to: 8 with: $ )].
		aStream cr].

	aStream
		cr; nextPutAll: ('Total' padded: #right to: 30 with: $ );
		nextPutAll: (totalCodeSpace printString padded: #left to: 12 with: $ );
		nextPutAll: (totalInstCount printString padded: #left to: 12 with: $ );
		nextPutAll: (totalInstSpace printString padded: #left to: 14 with: $ );
		nextPutAll: ((totalPercent roundTo: 0.1) printString padded: #left to: 8 with: $ ).