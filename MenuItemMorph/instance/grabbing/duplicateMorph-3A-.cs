duplicateMorph: evt
	"Make and return a duplicate of the receiver's argument"
	| dup menu |
	dup _ self duplicate isSelected: false.
	menu _ MenuMorph new defaultTarget: nil.
	menu addMorphFront: dup.
	menu bounds: self bounds.
	menu stayUp: true.
	evt hand grabMorph: menu from: owner. "duplicate was ownerless so use #grabMorph:from: here"
	^menu