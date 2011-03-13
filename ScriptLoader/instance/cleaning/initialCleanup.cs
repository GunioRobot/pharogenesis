initialCleanup
	"Perform various image cleanups in preparation for making a Squeak gamma release candidate image."
	"self new initialCleanup"
	
	Undeclared removeUnreferencedKeys.
	StandardScriptingSystem initialize.
	self resetToolSet.
	AppRegistry removeObsolete.
	FileServices removeObsolete. 

	(Object classPool at: #DependentsFields) size > 1 ifTrue: [self error:'Still have dependents'].
	Undeclared isEmpty ifFalse: [self error:'Please clean out Undeclared'].

	Smalltalk at: #Browser ifPresent:[:br| br initialize].
	ScriptingSystem deletePrivateGraphics.  "?"
	 
	self cleanUpChanges.
	ChangeSet current clear.
	ChangeSet current name: 'Unnamed'. 
	Smalltalk garbageCollect.
 
	"Reinitialize DataStream; it may hold on to some zapped entitities"
	DataStream initialize. 

	Smalltalk garbageCollect.
	ScheduledControllers := nil.
	Smalltalk garbageCollect.
	
	"SMSqueakMap default purge.  does not work"
	
