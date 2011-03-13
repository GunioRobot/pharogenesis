internalize: externalObject
	"PRIVATE -- We just read externalObject. Give it a chance to internalize. Return the internalized object.
	 If become: is expensive, we could use it less often. It's needed when we've already given out references to the object being read (while recursively reading its contents).  In other cases, we could just change the entry in the objects Dictionary.
	If an object is pointed at from inside itself, then it cannot have a different external and internal form.  It cannot be a PathFromHome or return anything other than self when sent comeFullyUpOnReload. (DiskProxy is OK)
	Objects that do return something other than self when sent comeFullyUpOnReload must not point to themselves, even indirectly.    8/14/96 tk"
	| internalObject |

	internalObject _ externalObject comeFullyUpOnReload.
	(externalObject ~~ internalObject and: [externalObject isKindOf: DiskProxy])
		ifTrue: [externalObject become: internalObject]
		ifFalse: [(self isAReferenceType:(self typeIDFor: internalObject))
			ifTrue: [self beginReference: internalObject]].
			"save the final object and give it out next time.  Substitute for become"
	^ internalObject