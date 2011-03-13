updateInstancesFrom: oldClass 
	"Recreate any existing instances of the argument, oldClass, as instances of 
	the receiver, which is a newly changed class. Permute variables as 
	necessary."
	"ar 7/15/1999: The updating below is possibly dangerous. If there are any
	contexts having an old instance as receiver it might crash the system if
	the new receiver in which the context is executed has a different layout.
	See bottom below for a simple example:"
	| oldInstances |

	Smalltalk garbageCollect.	"ensure that allInstances is correct"
	oldInstances _ oldClass allInstances asArray.
	self updateInstances: oldInstances from: oldClass isMeta: self isMeta.
	"Now fix up instances in segments that are out on the disk."
	ImageSegment allSubInstancesDo: [:seg |
		seg segUpdateInstancesOf: oldClass toBe: self isMeta: self isMeta].
	oldInstances _ nil.
	Smalltalk garbageCollect.	"ensure that old instances are gone"


"	| crashingBlock class |
	class _ Object subclass: #CrashTestDummy
		instanceVariableNames: 'instVar'
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Crash-Test'.
	class compile:'instVar: value instVar _ value'.
	class compile:'crashingBlock ^[instVar]'.
	crashingBlock _ (class new) instVar: 42; crashingBlock.
	Object subclass: #CrashTestDummy
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Crash-Test'.
	crashingBlock.
	crashingBlock value.
	"
