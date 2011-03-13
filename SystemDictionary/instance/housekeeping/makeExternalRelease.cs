makeExternalRelease
	"Smalltalk makeExternalRelease"
	(self confirm: SystemVersion current version , '
Is this the correct version designation?
If not, choose no, and fix it.')
		ifFalse: [^ self].
	"Object classPool at: #DependentsFields"
	self reclaimDependents.
	Preferences enable: #mvcProjectsAllowed.
	Preferences enable: #fastDragWindowForMorphic.
	Smalltalk at: #Browser ifPresent:[:br| br initialize].
	Undeclared isEmpty
		ifFalse: [self halt].
	ScriptingSystem deletePrivateGraphics.
	#(#Helvetica #Palatino #Courier )
		do: [:n | TextConstants
				removeKey: n
				ifAbsent: []].
	(Utilities classPool at: #UpdateUrlLists) copy
		do: [:pair | (pair first includesSubstring: 'Disney' caseSensitive: false)
				ifTrue: [(Utilities classPool at: #UpdateUrlLists)
						remove: pair]].
	(ServerDirectory serverNames copyWithoutAll: #('UCSBCreateArchive' 'UIUCArchive' 'UpdatesExtUIUC' 'UpdatesExtWebPage' ))
		do: [:sn | ServerDirectory removeServerNamed: sn].
	self  garbageCollect.
	self obsoleteClasses isEmpty
		ifFalse: [self halt].
	Symbol rehash.
	self halt: 'Ready to condense changes or sources'