makeSqueaklandReleasePhasePrepare
	"ReleaseBuilder new makeSqueaklandReleasePhasePrepare"

	Undeclared removeUnreferencedKeys.
	StandardScriptingSystem initialize.
	Preferences initialize.
	"(Object classPool at: #DependentsFields) size > 1 ifTrue: [self error:'Still have dependents']."
	Undeclared isEmpty ifFalse: [self error:'Please clean out Undeclared'].

	"Dump all projects"
	Project allSubInstancesDo:[:prj| prj == Project current ifFalse:[Project deletingProject: prj]].

	"Set new look so we don't need older fonts later"
	StandardScriptingSystem applyNewEToyLook.

	Browser initialize.
	ScriptingSystem deletePrivateGraphics.
	ChangeSorter removeChangeSetsNamedSuchThat:
		[:cs| cs name ~= ChangeSet current name].
	ChangeSet current clear.
	ChangeSet current name: 'Unnamed1'.
	Smalltalk garbageCollect.
	"Reinitialize DataStream; it may hold on to some zapped entitities"
	DataStream initialize.
	"Remove existing player references"
	References keys do:[:k| References removeKey: k].

	Smalltalk garbageCollect.
	ScheduledControllers _ nil.
	Smalltalk garbageCollect.
