fixObsoleteReferencesTo: oldClasses
	"Fix all obsolete references to the given set of outdated classes"
	| obsoleteClasses obj |
	progress == nil ifFalse:[progress value:'Fixing obsolete class references...'].
	"Prepare a map of obsolete classes"
	obsoleteClasses _ self mapObsoleteClassesToTemps: oldClasses.
	"Sanity check for debugging"
	"oldClasses size = obsoleteClasses size ifFalse:[self error:'Obsolete classes size mismatch']."
	"Fix the methods"
	self fixObsoleteMethodsFrom: oldClasses map: obsoleteClasses.
	"Now search and fix all dangerous objects"
	obj _ 0 someObject.
	[0 == obj] whileFalse:[
		"Avoid proxies on the disk.  See below."
		obj isInMemory ifTrue:[
			(obj isBehavior and:[obsoleteClasses includesKey: obj superclass]) ifTrue:[
				(obsoleteClasses includesKey: obj) ifFalse:[
						obj superclass: (obsoleteClasses at: obj superclass)]]].
		obj _ obj nextObject.
	].

"Three kinds of ProtoObjects need to be considered:
ObjectTracer and ObjectViewer		OK to test.  They are not Behaviors, and the object they represent will be found and fixed.  Traces may be recorded, but they should be.

ObjectOut and MorphObjectOut		Skip them.  The objects they represent are in SqueakPages, and are not really in this image.  Do not want to bring them all in!

ImageSegmentRootStub		Skip them.  Might stand for a class, or its segment might contain a class.  But, that class can't be the one being cleaned up now.  If instances of the class being fixed are in a segment, the class is in the outPointers, and will be found normally.
"
