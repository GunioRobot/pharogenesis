convert: misShapenInst to: goodClass
	"Go through the normal instance conversion process and return a modern object."

	| newName className oldInstVars anObject varMap supers this sel |
	goodClass isVariable ifTrue: [
		goodClass error: 'shape change for variable class not implemented yet'].
	newName _ goodClass name.
	className _ renamed keyAtValue: newName ifAbsent: [newName].
		"A problem here if two classes map to the same one!"
	oldInstVars _ structures at: className.
	anObject _ goodClass basicNew.

	varMap _ Dictionary new.	"later, indexed vars as (1 -> val) etc."
	2 to: oldInstVars size do: [:ind |
		varMap at: (oldInstVars at: ind) put: (misShapenInst instVarAt: ind-1)].

	"Give each superclass a chance to make its changes"
	self storeInstVarsIn: anObject from: varMap. 	"ones with the same names"
	supers _ OrderedCollection with: (this _ className).
	[(this _ superclasses at: this) = 'nil'] whileFalse: [supers addFirst: this].
	supers do: [:aName |	
		sel _ reshaped at: aName ifAbsent: [nil].
		sel ifNotNil: [
			anObject _ anObject perform: sel with: varMap with: self]].
				"do the mapping"
	^ anObject
