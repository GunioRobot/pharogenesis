instVarInfo: anObject
	"Return the object to write on the outgoing file that contains the structure of each class we are about to write out.  Must be an Array whose first element is 'class structure'.  Its second element is a Dictionary of pairs of the form #Rectangle -> #(<classVersion> 'origin' 'corner').  "

	"Make a pass through the objects, not writing, but recording the classes.  Construct a database of their inst vars and any version info (classVersion)."

	| dummy refs cls newSupers |
	dummy _ ReferenceStream on: (DummyStream on: nil).
		"Write to a fake Stream, not a file"
	"Collect all objects"
	dummy rootObject: anObject.	"inform him about the root"
	dummy nextPut: anObject.
	refs _ dummy references.
	structures _ Dictionary new.
	superclasses _ Dictionary new.
	objCount _ refs size.		"for progress bar"
		"Note that Dictionary must not change its implementation!  If it does, how do we read this reading information?"
	refs keysDo: [:each | 
		cls _ each class.
		cls class == Metaclass ifFalse: [
			structures at: cls name put: false]].
	"Save work by only computing inst vars once for each class"
	newSupers _ Set new.
	structures keysDo: [:nm | 
		cls _ Smalltalk at: nm.
		cls allSuperclasses do: [:aSuper |
			structures at: aSuper name ifAbsent: [newSupers add: aSuper name]]].
			"Don't modify structures during iteration"
	newSupers do: [:nm | structures at: nm put: 3].	"Get all superclasses into list"
	structures keysDo: [:nm | "Nothing added to classes during loop"
		cls _ Smalltalk at: nm.
		structures at: nm put: 
			((Array with: cls classVersion), (cls allInstVarNames)).
		superclasses at: nm ifAbsent: [
				superclasses at: nm put: cls superclass name]].
	^ Array with: 'class structure' with: structures with: 'superclasses' with: superclasses