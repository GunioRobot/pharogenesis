rememberKeyboardFocus: aMorph
	"Record the current keyboard focus for the receiver."
	
	|m|
	m :=aMorph.
	(m notNil and: [(m hasOwner: self) not])
		ifTrue: [m := nil].
	self setProperty: #rememberedFocus toValue: m