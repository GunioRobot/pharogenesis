readShortInst
	"PRIVATE -- Read the contents of an arbitrary instance.
	 ASSUMES: readDataFrom:size: sends me beginReference: after it
	   instantiates the new object but before reading nested objects.
	 NOTE: We must restore the current reference position after
	   recursive calls to next.
Three cases for files from older versions of the system:
1) Class has not changed shape, read it straight.
2) Class has changed instance variables (or needs fixup).  Call a particular method to do it.
3) There is a new class instead.  Find it, call a particular method to read.
1/7/97 tk
	All classes used to construct the structures dictionary *itself* need to be in 'steady' and they must not change!  See setStream:"
	| instSize className refPosn anObject newName newClass dict oldInstVars sel supers this |

	instSize _ (byteStream next) - 1.	"one byte of size"
	refPosn _ self getCurrentReference.
	className _ self readShortRef.	"class symbol in two bytes of file pos"
	self setCurrentReference: refPosn.  "remember pos before readDataFrom:size:"
	newName _ renamed at: className ifAbsent: [className].
	newClass _ Smalltalk at: newName.
	(steady includes: newClass) ifTrue: [
	 	anObject _ newClass isVariable "Create it here"
			ifFalse: [newClass basicNew]
			ifTrue: [newClass basicNew: instSize - (newClass instSize)].
		anObject _ anObject readDataFrom: self size: instSize.
		self setCurrentReference: refPosn.  "before returning to next"
		^ anObject].
	oldInstVars _ structures at: className ifAbsent: [
			self error: 'class is not in structures list'].	"Missing in object file"
	anObject _ newClass createFrom: self size: instSize version: oldInstVars.
		"only create the instance"
	self beginReference: anObject.
	dict _ self catalogValues: oldInstVars size: instSize.
		"indexed vars as (1 -> val) etc."

	"Give each superclass a chance to make its changes"
	self storeInstVarsIn: anObject from: dict.	"ones with the same names"
	supers _ OrderedCollection with: className.
	this _ className.
	[(this _ superclasses at: this) = 'nil'] whileFalse: [
		supers addFirst: this].
	supers do: [:aName |	
		sel _ reshaped at: aName ifAbsent: [nil].
		sel ifNotNil: [
			anObject _ anObject perform: sel with: dict with: self]].	"exceptions"
	self setCurrentReference: refPosn.  "before returning to next"
	^ anObject