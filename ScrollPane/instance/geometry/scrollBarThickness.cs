scrollBarThickness
	"Includes border"
	| result |
	result := Preferences scrollBarsNarrow
				ifTrue: [10]
				ifFalse: [14].

	self flatColoredScrollBarLook
		ifFalse: [result := result + 2].
	
	^ result