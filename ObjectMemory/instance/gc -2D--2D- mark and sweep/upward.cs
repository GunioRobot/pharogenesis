upward
	"Return from marking an object below. Incoming:
		field = oop we just worked on, needs to be put away
		parentField = where to put it in our object
	NOTE: Type field of object below has already been restored!!!"

	| type header |
	self inline: true.

	(parentField bitAnd: 1) = 1 ifTrue: [
		parentField = GCTopMarker ifTrue: [
			"top of the chain"
			header _ (self longAt: field) bitAnd: AllButTypeMask.
			type _ self rightType: header.
			self longAt: field put: header + type.  "install type on class oop"
			^ Done
		] ifFalse: [
			"was working on the extended class word"
			child _ field.	"oop of class"
			field _ parentField - 1.  "class word, ** clear the low bit **"
			parentField _ self longAt: field.
			header _ self longAt: field+4.  "base header word"
			type _ self rightType: header.
			self longAt: field put: child + type.  "install type on class oop"
			field _ field + 4.  "point at header"
			"restore type bits"
			header _ header bitAnd: AllButTypeMask.
			self longAt: field put: (header + type).
			^ Upward
		].
	] ifFalse: [
		"normal"
		child _ field.  "who we worked on below"
		field _ parentField.  "where to put it"
		parentField _ self longAt: field.
		self longAt: field put: child.
		field _ field - 4.  "point at header"
		^ StartField
	].