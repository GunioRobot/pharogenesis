who
	"Answer an Array of the class in which the receiver is defined and the 
	selector to which it corresponds."

	| sel |
	self systemNavigation allBehaviorsDo: 
			[:class | 
			(sel := class methodDict keyAtIdentityValue: self ifAbsent: [nil]) 
				ifNotNil: [^Array with: class with: sel]].
	^Array with: #unknown with: #unknown