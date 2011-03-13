topDownDrawOn: aCanvas
	"Draw me and then my submorphs from back to front.
	Return true if I completely fill the canvas clipping region."
	| clipRect |
	(aCanvas isVisible: self fullBounds) ifFalse: [^ self].
	clipRect _ aCanvas clipRect.
	self submorphsDo:  "Front to back..."
		[:m | "Look for a submorph that fills the region"
		(m drawOnFills: clipRect) ifTrue:
				["If any submorph fills the region, then display it
				and those in front, and return."
				(submorphs findFirst: [:x | x==m]) to: 1 by: -1 do:
					[:i | (submorphs at: i) topDownDrawOn: aCanvas].
				^ self]].
	"Otherwise do a normal display"
	self fullDrawOn: aCanvas