hideFill: fillIndex depth: depth
	"Make the fill style with the given index invisible"
	| index newTopIndex newTop newDepth newRightX |
	self inline: false.
	index _ self findStackFill: fillIndex depth: depth.
	index = -1 ifTrue:[^false].

	index = 0 ifTrue:[
		self freeStackFillEntry.
		^true].

	"Fill is visible - replace it with the last entry on the stack"
	self stackFillValue: index put: (self stackFillValue: 0).
	self stackFillDepth: index put: (self stackFillDepth: 0).
	self stackFillRightX: index put: (self stackFillRightX: 0).
	self freeStackFillEntry.
	(self stackFillSize <= self stackFillEntryLength) ifTrue:[^true]. "Done"

	"Find the new top fill"
	newTopIndex _ 0.
	index _ self stackFillEntryLength.
	[index < self stackFillSize] whileTrue:[
		(self fillSorts: index before: newTopIndex)
			ifTrue:[newTopIndex _ index].
		index _ index + self stackFillEntryLength.
	].
	(newTopIndex + self stackFillEntryLength = self stackFillSize) 
		ifTrue:[^true]. "Top fill not changed"
	newTop _ self stackFillValue: newTopIndex.
	self stackFillValue: newTopIndex put: self topFillValue.
	self topFillValuePut: newTop.
	newDepth _ self stackFillDepth: newTopIndex.
	self stackFillDepth: newTopIndex put: self topFillDepth.
	self topFillDepthPut: newDepth.
	newRightX _ self stackFillRightX: newTopIndex.
	self stackFillRightX: newTopIndex put: self topFillRightX.
	self topFillRightXPut: newRightX.
	^true