exportSegmentWithCatagories: catList classes: classList
	"Store my project out on the disk as an *exported* ImageSegment.  All outPointers will be in a form that can be resolved in the target image.  Name it <project name>.extSeg.  What do we do about subProjects, especially if they are out as local image segments?  Force them to come in?
	Player classes are included automatically."

| is response str ans revertSeg roots holder |
"world == World ifTrue: [^ false]."
	"self inform: 'Can''t send the current world out'."
world isMorph ifFalse: [
	self projectParameters at: #isMVC put: true.
	^ false].	"Only Morphic projects for now"
world ifNil: [^ false].  world presenter ifNil: [^ false].

Utilities emptyScrapsBook.
World currentHand objectToPaste ifNotNil: [
	response _ (PopUpMenu labels: 'Delete\Keep' withCRs)
		startUpWithCaption: 'Hand is holding a Morph in its paste buffer:\' withCRs,
			World currentHand objectToPaste printString.
	response = 1 ifTrue: [World currentHand clearPasteBuffer]].
world fullReleaseCachedState. 
world cleanseStepList.
world localFlapTabs size = world flapTabs size ifFalse: [
	self error: 'Still holding onto Global flaps'].
world releaseSqueakPages.
holder _ Project allInstances.	"force them in to outPointers, where DiskProxys are made"

"Just export me, not my previous version"
revertSeg _ self projectParameters at: #revertToMe ifAbsent: [nil].
self projectParameters removeKey: #revertToMe ifAbsent: [].

roots _ OrderedCollection new.
roots add: self; add: world; add: transcript; add: changeSet; add: thumbnail.
roots add: world activeHand; addAll: classList; addAll: (classList collect: [:cls | cls class]).
catList do: [:sysCat | 
	(SystemOrganization listAtCategoryNamed: sysCat asSymbol) do: [:symb |
		roots add: (Smalltalk at: symb); add: (Smalltalk at: symb) class]].

is _ ImageSegment new copyFromRootsForExport: roots asArray.	"world, and all Players"

is state = #tooBig ifTrue: [^ false].
str _ ''.
is segment size < 3000 ifTrue: [
	str _ 'Segment is only ', is segment size printString, ' long.'].
(is outPointers detect: [:out | out isMorph] ifNone: [nil]) ifNotNil: [
	str _ str, '\Morphs are pointed at from the outside.' withCRs].
(is outPointers includes: world) ifTrue: [
	str _ str, '\Project''s own world is not in the segment.' withCRs].
str isEmpty ifFalse: [
	ans _ (PopUpMenu labels: 'Do not write file
Write file anyway
Debug') startUpWithCaption: str.
	ans = 1 ifTrue: [
		revertSeg ifNotNil: [projectParameters at: #revertToMe put: revertSeg].
		^ false].
	ans = 3 ifTrue: [self halt: 'Segment not written']].

is writeForExportWithSources: self name, '.pr'.
revertSeg ifNotNil: [projectParameters at: #revertToMe put: revertSeg].
holder.
^ true
