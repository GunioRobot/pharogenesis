shoutAboutToStyle: aPluggableShoutMorphOrView
	"This is a notification that aPluggableShoutMorphOrView is about to re-style its text.
	Set the classOrMetaClass in aPluggableShoutMorphOrView, so that identifiers
	will be resolved correctly.
	Answer true to allow styling to proceed, or false to veto the styling"
	| type |
	
	self showingSource ifFalse: [^false].
	type := self editSelection.
	(#(newMessage editMessage editClass newClass) includes: type) ifFalse:[^false].
	aPluggableShoutMorphOrView classOrMetaClass: (type = #editClass ifFalse:[self selectedClassOrMetaClass]).
	^true