subViewContainingCharacter: aCharacter
	"Answer the receiver's subView that corresponds to the key, aCharacter. 
	Answer nil if no subView is selected by aCharacter."

	self subViews reverseDo: 
		[:aSubView |
		(aSubView shortcutCharacter = aCharacter) ifTrue: [^aSubView]].
	^nil	
