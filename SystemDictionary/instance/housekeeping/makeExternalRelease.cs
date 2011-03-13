makeExternalRelease		"Smalltalk makeExternalRelease"
	(self confirm: self version , '
Is this the correct version designation?
If not, choose no, and fix it.') ifFalse: [^ self].
	"Object classPool at: #DependentsFields"
	Smalltalk reclaimDependents.
	Preferences enable: #allowMVCprojects.
	Preferences enable: #fastDragWindowForMorphic.
	Browser initialize.
	Undeclared isEmpty ifFalse: [self halt].
	ScriptingSystem deletePrivateGraphics.
	#(Helvetica Palatino Courier) do:
		[:n | TextConstants removeKey: n ifAbsent: []].
	(Utilities classPool at: #UpdateUrlLists) copy do:
		[:pair | (pair first includesSubstring: 'Disney' caseSensitive: false) ifTrue: [
			(Utilities classPool at: #UpdateUrlLists) remove: pair]].
	(ServerDirectory serverNames copyWithoutAll: #('UCSBCreateArchive' 'UIUCArchive' 'UpdatesExtUIUC' 'UpdatesExtWebPage'))
		do: [:sn | ServerDirectory removeServerNamed: sn].
	Smalltalk garbageCollect.
	Smalltalk obsoleteClasses isEmpty ifFalse: [self halt].
	Symbol rehash.
	self halt: 'Ready to condense changes or sources'.
	SystemDictionary removeSelector: #makeExternalRelease.