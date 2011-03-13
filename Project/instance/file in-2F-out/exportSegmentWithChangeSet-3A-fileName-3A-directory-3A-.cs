exportSegmentWithChangeSet: aChangeSetOrNil fileName: aFileName directory: aDirectory
	"Store my project out on the disk as an *exported* ImageSegment.  All outPointers will be in a form that can be resolved in the target image.  Name it <project name>.extSeg.  What do we do about subProjects, especially if they are out as local image segments?  Force them to come in?
	Player classes are included automatically."

	| is str ans revertSeg roots holder |

	"An experimental version to fileout a changeSet first so that a project can contain its own classes"



world isMorph ifFalse: [
	self projectParameters at: #isMVC put: true.
	^ false].	"Only Morphic projects for now"
world ifNil: [^ false].  world presenter ifNil: [^ false].

Utilities emptyScrapsBook.
world currentHand pasteBuffer: nil.	  "don't write the paste buffer."
world currentHand mouseOverHandler initialize.	  "forget about any references here"
	"Display checkCurrentHandForObjectToPaste."
Command initialize.
world clearCommandHistory.
world fullReleaseCachedState; releaseViewers. 
world cleanseStepList.
world localFlapTabs size = world flapTabs size ifFalse: [
	self error: 'Still holding onto Global flaps'].
world releaseSqueakPages.
ScriptEditorMorph writingUniversalTiles: (world valueOfProperty: #universalTiles).
holder _ Project allProjects.	"force them in to outPointers, where DiskProxys are made"

"Just export me, not my previous version"
revertSeg _ self projectParameters at: #revertToMe ifAbsent: [nil].
self projectParameters removeKey: #revertToMe ifAbsent: [].

roots _ OrderedCollection new.
roots add: self; add: world; add: transcript; add: changeSet; add: thumbnail.
roots add: world activeHand.

	"; addAll: classList; addAll: (classList collect: [:cls | cls class])"

roots _ roots reject: [ :x | x isNil].	"early saves may not have active hand or thumbnail"

is _ ImageSegment new copySmartRootsExport: roots asArray.
	"old way was (is _ ImageSegment new copyFromRootsForExport: roots asArray)"

is state = #tooBig ifTrue: [^ false].

str _ ''.
"considered legal to save a project that has never been entered"
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

is writeForExportWithSources: aFileName inDirectory: aDirectory changeSet: aChangeSetOrNil.
revertSeg ifNotNil: [projectParameters at: #revertToMe put: revertSeg].
holder.
world flapTabs do: [:ft | 
		(ft respondsTo: #unhibernate) ifTrue: [ft unhibernate]].
is arrayOfRoots do: [:obj |
	obj class == ScriptEditorMorph ifTrue: [obj unhibernate]].
^ true
