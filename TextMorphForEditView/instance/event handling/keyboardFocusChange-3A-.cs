keyboardFocusChange: aBoolean 
	"rr 3/21/2004 22:55 : removed the #ifFalse: branch, 
	which was responsible of the deselection of text when the 
	paragraph lost focus. This way selection works in a more standard 
	way, and this permits the menu keyboard control to be really effective"
	paragraph isNil ifFalse:[paragraph focused: aBoolean].
	aBoolean 
		ifTrue: 
			["A hand is wanting to send us characters..."

			self hasFocus ifFalse: [self editor	"Forces install"]].
	self changed.
