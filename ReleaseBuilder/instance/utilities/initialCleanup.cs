initialCleanup
	"Perform various image cleanups in preparation for making a Squeak gamma release candidate image."
	"ReleaseBuilder new initialCleanup"
	
	Undeclared removeUnreferencedKeys.
	StandardScriptingSystem initialize.

	(Object classPool at: #DependentsFields) size > 1 ifTrue: [self error:'Still have dependents'].
	Undeclared isEmpty ifFalse: [self error:'Please clean out Undeclared'].

	Browser initialize.
	ScriptingSystem deletePrivateGraphics.  "?"
	
	self cleanUpChanges.
	ChangeSet current clear.
	ChangeSet current name: 'Unnamed1'.
	Smalltalk garbageCollect.

	"Reinitialize DataStream; it may hold on to some zapped entitities"
	DataStream initialize.

	Smalltalk garbageCollect.
	ScheduledControllers _ nil.
	Smalltalk garbageCollect.
	
	SMSqueakMap default purge.
	
